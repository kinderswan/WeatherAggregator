using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models
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
