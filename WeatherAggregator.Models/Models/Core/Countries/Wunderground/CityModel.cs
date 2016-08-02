using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Core.Countries.Wunderground
{
	public class CityModel
	{
		[JsonProperty(PropertyName = "name")]
		public string CityName { get; set; }

		[JsonProperty(PropertyName = "state")]
		public string StateName { get; set; }

		[JsonProperty(PropertyName = "country_name")]
		public string CountryName { get; set; }
	}
}
