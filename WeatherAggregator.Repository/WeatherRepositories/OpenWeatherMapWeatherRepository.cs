using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.OpenWeatherMap;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Infrastructure.Interfaces;
using WeatherAggregator.Repository.WeatherRepositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.WeatherRepositories
{
    public class OpenWeatherMapWeatherRepository : RepositoryBase<OpenWeatherMapWeatherModel>, IRepository<OpenWeatherMapWeatherModel>, IWeatherRepository
    {
        private const string WeatherCountryStateURL = @"http://api.openweathermap.org/data/2.5/weather?q={0},{1},{2}&appid=5c534ef4999710bd65efedf91d6295e4&units=metric";

        private const string WeatherCountryURL = @"http://api.openweathermap.org/data/2.5/weather?q={0},{1}&appid=5c534ef4999710bd65efedf91d6295e4&units=metric";

        public OpenWeatherMapWeatherRepository() { }

        public OpenWeatherMapWeatherRepository(IHttpRequestor requestor) : base(requestor) { }

        public WeatherConventionModel GetWeatherData(CityModel cityModel)
        {
            var result = base.GetResponseFromUrl(this.BuildGetRequestUrl(cityModel));
            return Mapper.Map<OpenWeatherMapWeatherModel, WeatherConventionModel>(result);
        }

        private string BuildGetRequestUrl(CityModel model)
        {
            return string.IsNullOrEmpty(model.StateName) ?
                string.Format(OpenWeatherMapWeatherRepository.WeatherCountryURL, model.CountryName, model.CityName) :
                string.Format(OpenWeatherMapWeatherRepository.WeatherCountryStateURL, model.CountryName, model.StateName, model.CityName);
        }
    }
}
