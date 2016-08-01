using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.ThePrintfulApi
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
