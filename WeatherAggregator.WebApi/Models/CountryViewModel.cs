using System.Collections.Generic;

namespace WeatherAggregator.WebApi.Models
{
	public class CountryViewModel
	{
		public string CountryCode { get; set; }

		public string CountryName { get; set; }

		public List<StateViewModel> States { get; set; }
	}
}
