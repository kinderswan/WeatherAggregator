using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;

namespace WeatherAggregator.Repository.WeatherRepositories.Interfaces
{
    public interface IWeatherRepository
    {
        WeatherConventionModel GetWeatherData(CityModel cityModel);
    }
}
