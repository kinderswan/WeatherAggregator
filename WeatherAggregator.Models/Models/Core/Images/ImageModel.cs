using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Core.Images
{
	public class ImageModel
	{
		[JsonProperty(PropertyName = "webformatURL")]
		public string ImageUrl { get; set; }
	}
}
