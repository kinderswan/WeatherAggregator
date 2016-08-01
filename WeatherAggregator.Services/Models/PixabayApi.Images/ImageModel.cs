using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAggregator.Services.Models.PixabayApi.Images
{
	public class ImageModel
	{
		[JsonProperty(PropertyName = "webformatURL")]
		public string ImageUrl { get; set; }
	}
}
