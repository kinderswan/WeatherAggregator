using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Core.Images
{
	/// <summary>
#pragma warning disable 1570
	/// Api is from https://pixabay.com/api/?key=3018114-ef10ea70a2ba5da78d32b52be&q=yellow+flowers&image_type=photo
#pragma warning restore 1570
	/// Api key is 3018114-ef10ea70a2ba5da78d32b52be
	/// </summary>
	public class ImagesCollectionModel
	{
		[JsonProperty(PropertyName = "hits")]
		public List<ImageModel> Images { get; set; }
	}
}
