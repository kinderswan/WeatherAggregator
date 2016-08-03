using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;

namespace WeatherAggregator.Services.WeatherServices.Interfaces
{
	public interface IOpenWeatherMapWeatherService
	{
		WeatherConventionModel GetWeather(CityModel cityModel);
	}
}
