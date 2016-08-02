﻿using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Weather.Wunderground;

namespace WeatherAggregator.Services.WeatherServices.Interfaces
{
	public interface IWundergroundWeatherService
	{
		WeatherModel GetWeather(CityModel cityModel);
	}
}
