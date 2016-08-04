using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Weather.OpenWeatherMap
{
	public class OpenWeatherMapMain
	{
		[JsonProperty(PropertyName = "temp")]
		public double Temperature { get; set; }

		[JsonProperty(PropertyName = "humidity")]
		public int Humidity { get; set; }
	}
}
