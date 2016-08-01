using Newtonsoft.Json;

namespace WeatherAggregator.Rest.Tests.Models
{
	public class CurrentObservation
	{
		[JsonProperty(PropertyName = "display_location")]
		public DisplayLocation DisplayLocation { get; set; }

		[JsonProperty(PropertyName = "temperature_string")]
		public string Temperature { get; set; }

		[JsonProperty(PropertyName = "temp_c")]
		public double TemperatureCelsius { get; set; }

		[JsonProperty(PropertyName = "relative_humidity")]
		public string RelativeHumidity { get; set; }

		[JsonProperty(PropertyName = "wind_string")]
		public string Wind { get; set; }

		[JsonProperty(PropertyName = "wind_dir")]
		public string WindDirection { get; set; }

		[JsonProperty(PropertyName = "wind_degrees")]
		public int WindDegrees { get; set; }

		[JsonProperty(PropertyName = "wind_kph")]
		public double WindSpeed { get; set; }

		[JsonProperty(PropertyName = "wind_gust_kph")]
		public string WindGustSpeed { get; set; }

		[JsonProperty(PropertyName = "dewpoint_string")]
		public string DewPoint { get; set; }

		[JsonProperty(PropertyName = "dewpoint_c")]
		public int DewPointCelsius { get; set; }

		[JsonProperty(PropertyName = "feelslike_string")]
		public string Feelslike { get; set; }

		[JsonProperty(PropertyName = "feelslike_c")]
		public string FeelslikeCelsius { get; set; }

		[JsonProperty(PropertyName = "visibility_km")]
		public string Visibility { get; set; }

		[JsonProperty(PropertyName = "icon")]
		public string IconDefinition { get; set; }

		[JsonProperty(PropertyName = "icon_url")]
		public string IconUrl { get; set; }
	}
}
