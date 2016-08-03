using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.Wunderground;

namespace WeatherAggregator.Services.WeatherServices.Interfaces
{
	public interface IWundergroundWeatherService
	{
		WeatherConventionModel GetWeather(CityModel cityModel);
	}
}
