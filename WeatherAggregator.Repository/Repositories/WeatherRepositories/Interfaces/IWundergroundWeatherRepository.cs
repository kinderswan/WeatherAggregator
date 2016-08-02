using WeatherAggregator.Models.Models.Core.Countries.Wunderground;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.Repository.Infrastructure.Interfaces;

namespace WeatherAggregator.Repository.Repositories.WeatherRepositories.Interfaces
{
	public interface IWundergroundWeatherRepository : IRepository<WeatherModel>
	{
		WeatherModel GetWeatherData(CityModel cityModel);
	}
}
