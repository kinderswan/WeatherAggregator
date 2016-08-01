using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.WundergroundApi
{
	/// <summary>
	/// Weather model is constructed from http://api.wunderground.com api
	/// </summary>
	public class WeatherModel : DisplayLocation
	{
		[JsonProperty(PropertyName = "current_observation")]
		public CurrentObservation CurrentObservation { get; set; }
	}

	

	
}
