using System;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Mappings
{
	public class CitiesMapping : Profile
	{
		public new string ProfileName
		{
			get { return "CitiesMapping"; }
		}

		[Obsolete("Use the constructor instead. Will be removed in 6.0")]
		protected override void Configure()
		{
			CreateMap<CitiesCollectionModel, CitiesCollectionViewModel>();
			
			CreateMap<CityModel, CityViewModel>()
				.ForMember(x => x.CountryName, y => y.MapFrom(src => src.CountryName))
				.ForMember(x => x.CityName, y => y.MapFrom(src => src.CityName))
				.ForMember(x => x.StateName, y => y.MapFrom(src => src.StateName));
		}
	}
}