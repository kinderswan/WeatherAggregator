using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.ThePrintfulApi
{
	public class StateModel
	{
		[JsonProperty(PropertyName = "code")]
		public string StateCode { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string StateName { get; set; }
	}
}
