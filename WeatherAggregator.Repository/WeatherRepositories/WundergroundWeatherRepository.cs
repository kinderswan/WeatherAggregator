using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Infrastructure.Interfaces;
using WeatherAggregator.Repository.WeatherRepositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.WeatherRepositories
{
    public class WundergroundWeatherRepository : RepositoryBase<WundergroundWeatherModel>, IRepository<WundergroundWeatherModel>, IWeatherRepository
    {
        private const string WeatherCountryStateURL = @"http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}/{1}/{2}.json";

        private const string WeatherCountryURL = @"http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}/{1}.json";

        public WundergroundWeatherRepository() { }

        public WundergroundWeatherRepository(IHttpRequestor requestor) : base(requestor) { }

        public WeatherConventionModel GetWeatherData(CityModel cityModel)
        {
            var result = base.GetResponseFromUrl(this.BuildGetRequestUrl(cityModel));
            return Mapper.Map<WundergroundWeatherModel, WeatherConventionModel>(result);
        }

        private string BuildGetRequestUrl(CityModel model)
        {
            return string.IsNullOrEmpty(model.StateName) ?
                string.Format(WundergroundWeatherRepository.WeatherCountryURL, model.CountryName, model.CityName) :
                string.Format(WundergroundWeatherRepository.WeatherCountryStateURL, model.CountryName, model.StateName, model.CityName);
        }
    }
}
