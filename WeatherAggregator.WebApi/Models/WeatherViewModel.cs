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
	}
}