using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.OpenWeatherMap;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.WeatherServices.Interfaces;

namespace WeatherAggregator.Services.WeatherServices
{
	public class OpenWeatherMapWeatherService: IOpenWeatherMapWeatherService
	{
		private const string WeatherCountryStateURL = @"http://api.openweathermap.org/data/2.5/weather?q={0},{1},{2}&appid=5c534ef4999710bd65efedf91d6295e4&units=metric";

		private const string WeatherCountryURL = @"http://api.openweathermap.org/data/2.5/weather?q={0},{1}&appid=5c534ef4999710bd65efedf91d6295e4&units=metric";

		private readonly IWeatherRepository<OpenWeatherMapWeatherModel> weatherRepository;

		public OpenWeatherMapWeatherService() { }

		public OpenWeatherMapWeatherService(IWeatherRepository<OpenWeatherMapWeatherModel> weatherRepository)
		{
			this.weatherRepository = weatherRepository;
		}

		public WeatherConventionModel GetWeather(CityModel cityModel)
		{
			return this.weatherRepository.GetWeatherData(this.BuildGetRequestUrl(cityModel), Mapper.Map<OpenWeatherMapWeatherModel, WeatherConventionModel>);
		}

		private string BuildGetRequestUrl(CityModel model)
		{
			return string.IsNullOrEmpty(model.StateName) ?
				string.Format(OpenWeatherMapWeatherService.WeatherCountryURL, model.CountryName, model.CityName) :
				string.Format(OpenWeatherMapWeatherService.WeatherCountryStateURL, model.CountryName, model.StateName, model.CityName);
		}
	}
}
