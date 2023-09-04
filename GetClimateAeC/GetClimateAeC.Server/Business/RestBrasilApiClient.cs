using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using GetClimateAeC.Shared;
using RestSharp;

namespace GetClimateAeC.Server.Business
{
    public class RestBrasilApiClient : IRestBrasilApiClient
    {
        private readonly HttpClient _httpClient;
        private RestClient restClient;

        public RestBrasilApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            restClient = new RestClient(httpClient);
        }

        public async Task<List<City>> GetListCityDetails(string cityName)
        {
            try
            {
                var request = new RestRequest($"/cptec/v1/cidade/{cityName}", Method.Get);
                RestResponse response = await restClient.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                if (response.StatusCode != HttpStatusCode.OK)
                    return null;

                return JsonSerializer.Deserialize<List<City>>(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public async Task<CityClimate> GetCityClimate(string cityCode)
        {
            try
            {
                var request = new RestRequest($"cptec/v1/clima/previsao/{cityCode}", Method.Get);
                RestResponse response = await restClient.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                if (response.StatusCode != HttpStatusCode.OK)
                    return null;
                
                return JsonSerializer.Deserialize<CityClimate>(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public async Task<AirportClimate> GetAirportClimate(string icaoCode)
        {
            try
            {
                var request = new RestRequest($"/cptec/v1/clima/aeroporto/{icaoCode}", Method.Get);
                RestResponse response = await restClient.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                if (response.StatusCode != HttpStatusCode.OK)
                    return null;

                return JsonSerializer.Deserialize<AirportClimate>(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
