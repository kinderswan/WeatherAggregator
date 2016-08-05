using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Weather.OpenWeatherMap
{
	public class OpenWeatherMapWeatherModel
	{
		[JsonProperty(PropertyName = "main")]
		public OpenWeatherMapMain OpenWeatherMapMain { get; set; }

		[JsonProperty(PropertyName = "wind")]
		public OpenWeatherMapWind OpenWeatherMapWind { get; set; }

		[JsonProperty(PropertyName = "sys")]
		public OpenWeatherMapSys OpenWeatherMapCountry { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string CityName { get; set; }

        [JsonProperty(PropertyName = "weather")]
        public List<OpenWeatherMapWeather> OpenWeatherMapWeather { get; set; }
	}
}
