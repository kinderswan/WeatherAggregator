using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Weather.OpenWeatherMap
{
	public class OpenWeatherMapSys
	{
		[JsonProperty(PropertyName = "country")]
		public string Country { get; set; }
	}
}
