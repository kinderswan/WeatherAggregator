using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Images.Pixabay
{
	public class ImageModel
	{
		[JsonProperty(PropertyName = "webformatURL")]
		public string ImageUrl { get; set; }
	}
}
