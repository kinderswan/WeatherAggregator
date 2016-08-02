using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Core.Countries
{
	public class CountryModel
	{
		[JsonProperty(PropertyName = "code")]
		public string CountryCode { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string CountryName { get; set; }

		[JsonProperty(PropertyName = "states", NullValueHandling = NullValueHandling.Include)]
		public List<StateModel> States { get; set; }
	}
}
