﻿using Newtonsoft.Json;

namespace WeatherAggregator.Models.Models.Core.Countries.ThePrintful
{
	public class StateModel
	{
		[JsonProperty(PropertyName = "code")]
		public string StateCode { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string StateName { get; set; }
	}
}
