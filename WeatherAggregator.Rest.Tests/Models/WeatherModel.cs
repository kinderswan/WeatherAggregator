using Newtonsoft.Json;

namespace WeatherAggregator.Rest.Tests.Models
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
