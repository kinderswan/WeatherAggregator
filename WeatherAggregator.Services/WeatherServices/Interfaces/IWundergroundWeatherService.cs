using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Models.Models.Countries.Wunderground;
using WeatherAggregator.Models.Models.Weather.Wunderground;

namespace WeatherAggregator.Services.WeatherServices.Interfaces
{
	public interface IWundergroundWeatherService
	{
		WeatherModel GetWeather(CityModel cityModel);
	}
}
