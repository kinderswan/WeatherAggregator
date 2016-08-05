using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Weather.OpenWeatherMap
{
    public class OpenWeatherMapWeather
    {
        [JsonProperty(PropertyName = "description")]
        public string WeatherDescription { get; set; }
    }
}
