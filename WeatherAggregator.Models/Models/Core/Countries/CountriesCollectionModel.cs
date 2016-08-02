using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Core.Countries
{
	/// <summary>
	/// Api is from https://api.theprintful.com/countries
	/// </summary>
	public class CountriesCollectionModel
	{
		[JsonProperty(PropertyName = "result")]
		public List<CountryModel> Countries { get; set; }
	}
}
