using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.ThePrintfulApi
{
	public class CountriesCollectionModel
	{
		[JsonProperty(PropertyName = "result")]
		public List<CountryModel> Countries { get; set; }
	}
}
