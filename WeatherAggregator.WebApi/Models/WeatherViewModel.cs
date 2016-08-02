using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAggregator.WebApi.Models
{
	public class WeatherViewModel
	{
		public double Temperature { get; set; }

		public string Humidity { get; set; }

		public double WindSpeed { get; set; }

		public string WindDirection { get; set; }

		public double Feelslike { get; set; }

		public string Country { get; set; }

		public string State { get; set; }

		public string City { get; set; }
	}
}