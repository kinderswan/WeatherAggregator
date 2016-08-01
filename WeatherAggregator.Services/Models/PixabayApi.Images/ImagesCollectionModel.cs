using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.PixabayApi.Images
{
	/// <summary>
	/// Api is from https://pixabay.com/api/?key=3018114-ef10ea70a2ba5da78d32b52be&q=yellow+flowers&image_type=photo
	/// Api key is 3018114-ef10ea70a2ba5da78d32b52be
	/// </summary>
	public class ImagesCollectionModel
	{
		[JsonProperty(PropertyName = "hits")]
		public List<ImageModel> Images { get; set; }
	}
}
