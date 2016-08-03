using System;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.Wunderground;

namespace WeatherAggregator.WebApi.Mappings.WeatherModelsMappings
{
	public class WundergroundConventionMapping : Profile
	{
		public new string ProfileName
		{
			get { return "WundergroundConventionMapping"; }
		}

		[Obsolete("Use the constructor instead. Will be removed in 6.0")]
		protected override void Configure()
		{
			CreateMap<WundergroundWeatherModel, WeatherConventionModel>()
				.ForMember(temp => temp.Temperature, x => x.MapFrom(src => src.CurrentObservation.TemperatureCelsius))
				.ForMember(temp => temp.Humidity, x => x.MapFrom(src => src.CurrentObservation.RelativeHumidity))
				.ForMember(temp => temp.City, x => x.MapFrom(src => src.CurrentObservation.DisplayLocation.CityName))
				.ForMember(temp => temp.Country, x => x.MapFrom(
					src => string.IsNullOrEmpty(src.CurrentObservation.DisplayLocation.State)
						? src.CurrentObservation.DisplayLocation.StateName
						: src.CurrentObservation.DisplayLocation.CountryName))
				.ForMember(temp => temp.Feelslike, x => x.MapFrom(src => src.CurrentObservation.FeelslikeCelsius))
				.ForMember(temp => temp.WindDirection, x => x.MapFrom(src => src.CurrentObservation.WindDirection))
				.ForMember(temp => temp.WindSpeed, x => x.MapFrom(src => src.CurrentObservation.WindSpeed))
				.ForMember(temp => temp.State, x => x.MapFrom(src => src.CurrentObservation.DisplayLocation.StateName));
		}
	}
}