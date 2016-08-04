using Newtonsoft.Json;

namespace WeatherAggregator.WebApi.Models
{
	public class CityViewModel
	{
		public string CityName { get; set; }

		public string StateName { get; set; }

		public string CountryName { get; set; }
	}
}
