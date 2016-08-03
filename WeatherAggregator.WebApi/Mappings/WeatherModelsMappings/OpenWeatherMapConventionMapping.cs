using System;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.OpenWeatherMap;
using WeatherAggregator.Models.Models.Weather.Wunderground;

namespace WeatherAggregator.WebApi.Mappings.WeatherModelsMappings
{
	public class OpenWeatherMapConventionMapping : Profile
	{
		public new string ProfileName
		{
			get { return "OpenWeatherMapConventionMapping"; }
		}

		[Obsolete("Use the constructor instead. Will be removed in 6.0")]
		protected override void Configure()
		{
			CreateMap<OpenWeatherMapWeatherModel, WeatherConventionModel>()
				.ForMember(temp => temp.Temperature, x => x.MapFrom(src => src.OpenWeatherMapMain.Temperature))
				.ForMember(temp => temp.Humidity, x => x.MapFrom(src => src.OpenWeatherMapMain.Humidity))
				.ForMember(temp => temp.City, x => x.MapFrom(src => src.CityName))
				.ForMember(temp => temp.Country, x => x.MapFrom(src => src.OpenWeatherMapCountry.Country))
				.ForMember(temp => temp.WindDegrees, x => x.MapFrom(src => src.OpenWeatherMapWind.WindDegrees))
				.ForMember(temp => temp.WindSpeed, x => x.MapFrom(src => src.OpenWeatherMapWind.WindSpeed));
		}
	}
}