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
