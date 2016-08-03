using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Mappings
{
	public class WeatherMapping : Profile
	{
		public new string ProfileName
		{
			get { return "WeatherMapping"; }
		}

		[Obsolete("Use the constructor instead. Will be removed in 6.0")]
		protected override void Configure()
		{
			CreateMap<WeatherConventionModel, WeatherViewModel>();
		}
	}
}