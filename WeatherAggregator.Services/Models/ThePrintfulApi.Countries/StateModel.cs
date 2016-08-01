using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.ThePrintfulApi.Countries
{
	public class StateModel
	{
		[JsonProperty(PropertyName = "code")]
		public string StateCode { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string StateName { get; set; }
	}
}
