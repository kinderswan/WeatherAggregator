using AutoMapper;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Mappings.WeatherModels
{
	public class WundergroundMapping : Profile
	{
		public new string ProfileName
		{
			get { return "WundergroundMapping"; }
		}

		protected override void Configure()
		{
			CreateMap<WeatherModel, WeatherViewModel>()
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