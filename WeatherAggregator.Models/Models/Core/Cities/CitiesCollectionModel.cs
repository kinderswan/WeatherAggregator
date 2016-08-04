using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Core.Cities
{
	public class CitiesCollectionModel
	{
		[JsonProperty(PropertyName = "results")]
		public List<CityModel> Cities { get; set; }
	}
}
