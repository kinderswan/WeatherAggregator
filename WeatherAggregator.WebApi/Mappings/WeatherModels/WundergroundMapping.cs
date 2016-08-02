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
				.ForMember(temp => temp.Humidity, x => x.MapFrom(src => src.CurrentObservation.RelativeHumidity));
		}
	}
}