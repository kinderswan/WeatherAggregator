using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAggregator.Models.Models.Core.Weather
{
	public class WeatherConventionModel
	{
		public double Temperature { get; set; }

		public string Humidity { get; set; }

		public double WindSpeed { get; set; }

		public string WindDirection { get; set; }

		public string Feelslike { get; set; }

		public string Country { get; set; }

		public string State { get; set; }

		public string City { get; set; }
	}
}
