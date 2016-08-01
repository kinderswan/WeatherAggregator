using Newtonsoft.Json;

namespace WeatherAggregator.Rest.Tests.Models
{
	public class DisplayLocation
	{
		[JsonProperty(PropertyName = "full")]
		public string FullCityName { get; set; }

		[JsonProperty(PropertyName = "city")]
		public string CityName { get; set; }

		[JsonProperty(PropertyName = "country")]
		public string CountryName { get; set; }
	}
}
