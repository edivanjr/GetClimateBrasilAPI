using GetClimateAeC.Shared;

namespace GetClimateAeC.Server.Business
{
    public interface IRestBrasilApiClient
    {
        public Task<List<City>> GetListCityDetails(string cityName);
        public Task<CityClimate> GetCityClimate(string cityCode);
        public Task<AirportClimate> GetAirportClimate(string icaoCode);
    }
}
