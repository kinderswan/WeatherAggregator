using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.WeatherServices.Interfaces;

namespace WeatherAggregator.Services.WeatherServices
{
	public class WundergroundWeatherService: IWundergroundWeatherService
	{
		private const string WeatherCountryStateURL = @"http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}/{1}/{2}.json";

		private const string WeatherCountryURL = @"http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}/{1}.json";

		private readonly IWeatherRepository<WundergroundWeatherModel> weatherRepository;

		public WundergroundWeatherService() { }

		public WundergroundWeatherService(IWeatherRepository<WundergroundWeatherModel> weatherRepository)
		{
			this.weatherRepository = weatherRepository;
		}

		public WeatherConventionModel GetWeather(CityModel cityModel)
		{
			return this.weatherRepository.GetWeatherData(this.BuildGetRequestUrl(cityModel), Mapper.Map<WundergroundWeatherModel, WeatherConventionModel>);
		}

		private string BuildGetRequestUrl(CityModel model)
		{
			return string.IsNullOrEmpty(model.StateName) ?
				string.Format(WundergroundWeatherService.WeatherCountryURL, model.CountryName, model.CityName) :
				string.Format(WundergroundWeatherService.WeatherCountryStateURL, model.CountryName, model.StateName, model.CityName);
		}
	}
}
