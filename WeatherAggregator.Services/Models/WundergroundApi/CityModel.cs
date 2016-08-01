using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.WundergroundApi
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
