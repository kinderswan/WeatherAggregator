using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Weather.OpenWeatherMap
{
	public class OpenWeatherMapWind
	{
		[JsonProperty(PropertyName = "speed")]
		public double WindSpeed { get; set; }

		[JsonProperty(PropertyName = "deg")]
		public double WindDegrees { get; set; }
	}
}
