using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;

namespace WeatherAggregator.Services.Interfaces
{
	public interface IWeatherService
	{
		WeatherConventionModel GetWeatherData(CityModel cityModel, string resourceName);
	}
}
