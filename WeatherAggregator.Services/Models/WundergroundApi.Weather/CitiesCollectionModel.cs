using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.WundergroundApi.Weather
{
	public class CitiesCollectionModel
	{
		[JsonProperty(PropertyName = "results")]
		public List<CityModel> Cities { get; set; }
	}
}
