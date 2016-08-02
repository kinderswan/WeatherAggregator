using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Countries.Wunderground
{
	public class CitiesCollectionModel
	{
		[JsonProperty(PropertyName = "results")]
		public List<CityModel> Cities { get; set; }
	}
}
