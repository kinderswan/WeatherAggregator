using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WeatherAggregator.Services.Models.WundergroundApi
{
	public class CitiesContainerResponse
	{
		[JsonProperty(PropertyName = "response")]
		public CitiesCollectionModel CitiesContainer { get; set; }
	}
}
