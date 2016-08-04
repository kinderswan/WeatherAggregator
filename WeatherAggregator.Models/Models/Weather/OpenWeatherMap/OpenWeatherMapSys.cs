using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Weather.OpenWeatherMap
{
	public class OpenWeatherMapSys
	{
		[JsonProperty(PropertyName = "country")]
		public string Country { get; set; }
	}
}
