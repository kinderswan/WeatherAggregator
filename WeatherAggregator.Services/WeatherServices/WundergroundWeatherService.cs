using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.Repository.Repositories.WeatherRepositories.Interfaces;
using WeatherAggregator.Services.WeatherServices.Interfaces;

namespace WeatherAggregator.Services.WeatherServices
{
	public class WundergroundWeatherService: IWundergroundWeatherService
	{
		private readonly IWundergroundWeatherRepository weatherRepository;

		public WundergroundWeatherService() { }

		public WundergroundWeatherService(IWundergroundWeatherRepository weatherRepository)
		{
			this.weatherRepository = weatherRepository;
		}

		public WeatherModel GetWeather(CityModel cityModel)
		{
			return this.weatherRepository.GetWeatherData(cityModel);
		}
	}
}
