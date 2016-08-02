using WeatherAggregator.Models.Models.Countries.Wunderground;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.Repository.Core.Interfaces;

namespace WeatherAggregator.Repository.Repositories.WeatherRepositories.Interfaces
{
	public interface IWundergroundWeatherRepository : IRepository<WeatherModel>
	{
		WeatherModel GetWeatherData(CityModel cityModel);
	}
}
