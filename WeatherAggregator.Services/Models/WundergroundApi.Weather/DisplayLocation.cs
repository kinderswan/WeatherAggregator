using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.WundergroundApi.Weather
{
	public class DisplayLocation
	{
		[JsonProperty(PropertyName = "full")]
		public string FullCityName { get; set; }

		[JsonProperty(PropertyName = "city")]
		public string CityName { get; set; }

		[JsonProperty(PropertyName = "country")]
		public string CountryName { get; set; }

		[JsonProperty(PropertyName = "state_name")]
		public string StateName { get; set; }
	}
}
