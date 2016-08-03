using System.Collections.Generic;
using Newtonsoft.Json;
using WeatherAggregator.Models.Models.Core.Cities;

namespace WeatherAggregator.WebApi.Models
{
	public class CitiesCollectionViewModel
	{
		public List<CityModel> Cities { get; set; }
	}
}
