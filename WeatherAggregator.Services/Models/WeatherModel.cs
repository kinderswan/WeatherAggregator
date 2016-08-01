using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models
{
	/// <summary>
	/// Weather model is constructed from api from http://api.wunderground.com
	/// </summary>
	public class WeatherModel
	{
		[JsonProperty(PropertyName = "current_observation")]
		public CurrentObservation CurrentObservation { get; set; }
	}

	

	
}
