using System.Collections.Generic;
using Newtonsoft.Json;
using WeatherAggregator.Models.Models.Core.Countries;

namespace WeatherAggregator.WebApi.Models
{
	public class CountriesCollectionViewModel
	{
		public List<CountryViewModel> Countries { get; set; }
	}
}
