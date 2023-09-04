using GetClimateAeC.Server.Business;
using GetClimateAeC.Server.Data;
using GetClimateAeC.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GetClimateAeC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimateBrasilAeC : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IRestBrasilApiClient _restBrasilApiClient;
        private readonly IConfiguration _configuration;
        public ClimateBrasilAeC(DataContext dataContext, IRestBrasilApiClient restBrasilApiClient, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _restBrasilApiClient = restBrasilApiClient;
            _configuration = configuration;
        }

        /// <summary>
        /// Na construção da aplicação e após vários testes na API da BrasilAPI, percebi que ao digitar o nome completo de uma cidade, o retorno sempre acusa erro
        /// Por exemplo, ao digitar Goiania, goiania, goiânia, e Goiânia sempre retorna  "message": "Erro ao buscar informações sobre cidade".
        /// Dito isso, para fins de teste recomendo apenas parte do nome da cidade desejada, por exemplo: Goi, Ana, Bel
        /// Aqui será retornado uma lista de possíveis cidades com código para pesquisa do clima das mesmas
        /// </summary>
       [HttpGet("GetListCityDetails/{cityName}")]
        public async Task<IActionResult> GetCityDetails(string cityName)
        {
            
            var listcityDetail = new List<City>();
            try
            {
                listcityDetail = await _restBrasilApiClient.GetListCityDetails(cityName);
                if (listcityDetail == null || listcityDetail.Count == 0)
                    return Ok("Não foram retornadas cidades para a pesquisa em questão. Por favor, tente novamente.");
                foreach (var city in listcityDetail)
                {
                    city.Id = Guid.NewGuid();
                    var citieInDb = await _dataContext.City.Where(x => x.Id_City == city.Id_City).FirstOrDefaultAsync();
                    if (citieInDb == null)
                        await _dataContext.City.AddAsync(city);
                }
                
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var erro = new ErrorLog
                {
                    Id = Guid.NewGuid(),
                    ErrorMessage = e.Message,
                    Date = DateTime.Now

                };
                await _dataContext.ErrorLog.AddAsync(erro);
                await _dataContext.SaveChangesAsync();
                return BadRequest(e.StackTrace);
            }
            
            
            return Ok(listcityDetail);
        }

        /// <summary>
        /// Retorna o clima da cidade usando o código da mesma.
        /// </summary>
        /// <param name="cityCode"></param>
        /// <returns></returns>
        // GET: api/<ClimateBrasilAeC>/GetCityClimateByCode/cityCode
        [HttpGet("GetCityClimateByCode/{cityCode}")]
        public async Task<IActionResult> GetCityClimateByCode(string cityCode)
        {
            var cityClimate = new CityClimate();
            try
            {
                cityClimate = await _restBrasilApiClient.GetCityClimate(cityCode);
                if (cityClimate == null)
                    return NotFound();
                cityClimate.Id = Guid.NewGuid();

                foreach (var cityClimateDetail in cityClimate.ClimateArray)
                {
                    cityClimateDetail.Id = Guid.NewGuid();
                    cityClimateDetail.OwnerId = cityClimate.Id;
                    await _dataContext.CityClimateArray.AddAsync(cityClimateDetail);

                }

                await _dataContext.CityClimate.AddAsync(cityClimate);
                await _dataContext.SaveChangesAsync();
                return Ok(cityClimate);
            }
            catch (Exception e)
            {
                var erro = new ErrorLog
                {
                    Id = Guid.NewGuid(),
                    ErrorMessage = e.Message,
                    Date = DateTime.Now

                };
                await _dataContext.ErrorLog.AddAsync(erro);
                await _dataContext.SaveChangesAsync();
                return BadRequest(e.StackTrace);
            }
        }

        /// <summary>
        /// Ao executar a pesquisa de localidades na API da BrasilAPI, não é retornado o código icao(necessário para pesquisa do clima do aeroporto) no corpo de uma única cidade,
        /// apenas na pesquisa de capitais. Visto que temos aeroportos com codigo icao e que não estão em uma capital, o consolidado de resultados não seria certeiro. Como temos
        /// a lista completa de codigos icao disponibilizada, acreditei que seria melhor inserir essa lista no banco, e ao apresenta-la junto com os nomes das cidades, ficaria
        /// mais fácil a busca de um aeroporto com o codigo em questão.
        /// </summary>
        /// <param name="icaoCode"></param>
        /// <returns></returns>
        // GET api/<ClimateBrasilAeC>/GetAirportClimateByIcaoCode/icaoCode
        [HttpGet("GetAirportClimateByIcaoCode/{icaoCode}")]
        public async Task<IActionResult> GetAirportClimateByIcaoCode(string icaoCode)
        {
            var airportClimate = new AirportClimate();
            try
            {
                airportClimate = await _restBrasilApiClient.GetAirportClimate(icaoCode);
                airportClimate.Id = Guid.NewGuid();
                await _dataContext.AirportClimate.AddAsync(airportClimate);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var erro = new ErrorLog
                {
                    Id = Guid.NewGuid(),
                    ErrorMessage = e.Message,
                    Date = DateTime.Now
                };
                await _dataContext.ErrorLog.AddAsync(erro);
                await _dataContext.SaveChangesAsync();
                return BadRequest(e.StackTrace);
            }
            return Ok(airportClimate);
        }

        /// <summary>
        /// Use este endpoint para obter a lista de todos os aeroportos do País e suas respectivas cidades acompanhado dos links das chamadas para obtenção
        /// do clima dos mesmos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListOfAirportCodes")]
        public async Task<IActionResult> GetListOfAirportCodes()
        {
            try
            {
                var icaoCodes = await _dataContext.AirportCodes.ToListAsync();
                if (!icaoCodes.Any())
                {
                    var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";",
                        HasHeaderRecord = true
                    };

                    DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                    using (var reader = new StreamReader($"{directoryInfo}\\Resources\\IcaoCodes.csv"))
                    using (var csv = new CsvReader(reader, configuration))
                    {
                        var records = csv.GetRecords<IcaoCodesFile>();

                        foreach (var record in records)
                        {
                            var airportCodes = new AirportCodes();
                            airportCodes.Id = Guid.NewGuid();
                            airportCodes.Acronym = record.Acronym;
                            airportCodes.Airport = record.Airport;
                            airportCodes.State = record.State;
                            airportCodes.LinkAirportClimateLocal = $"http://localhost:5159/api/ClimateBrasilAeC/GetAirportClimateByIcaoCode/{record.Acronym}";
                            airportCodes.LinkAirportClimateBrasilAPI = $"{_configuration["BrasilAPIUrl"]}/cptec/v1/clima/aeroporto/{record.Acronym}";
                            await _dataContext.AirportCodes.AddAsync(airportCodes);
                        }
                        
                        await _dataContext.SaveChangesAsync();
                    }
                }
                icaoCodes = await _dataContext.AirportCodes.ToListAsync();
                return Ok(icaoCodes);
            }
            catch (Exception e)
            {
                var erro = new ErrorLog
                {
                    Id = new Guid(),
                    ErrorMessage = e.Message,
                    Date = DateTime.Now

                };
                await _dataContext.ErrorLog.AddAsync(erro);
                await _dataContext.SaveChangesAsync();
                return BadRequest(e.StackTrace);
            }
            return Ok();
        }
    }
}
