﻿using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.WundergroundApi.Weather
{
	/// <summary>
	/// Api documentation at http://api.wunderground.com/weather/api/d/docs
	/// Example request is http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/CA/San_Francisco.json
	/// Api key is d560e8d2602ee998
	/// </summary>
	public class WeatherModel : DisplayLocation
	{
		[JsonProperty(PropertyName = "current_observation")]
		public CurrentObservation CurrentObservation { get; set; }
	}

	

	
}