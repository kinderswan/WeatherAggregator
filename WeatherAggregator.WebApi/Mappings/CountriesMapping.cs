using System;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Mappings
{
	public class CountriesMapping : Profile
	{
		public new string ProfileName
		{
			get { return "CountriesMapping"; }
		}

		[Obsolete("Use the constructor instead. Will be removed in 6.0")]
		protected override void Configure()
		{
			CreateMap<CountriesCollectionModel, CountriesCollectionViewModel>();
			
			CreateMap<CountryModel, CountryViewModel>()
				.ForMember(x => x.CountryName, y => y.MapFrom(src => src.CountryName))
				.ForMember(x => x.CountryCode, y => y.MapFrom(src => src.CountryCode))
				.ForMember(x => x.States, y => y.MapFrom(src => src.States));

			CreateMap<StateModel, StateViewModel>()
				.ForMember(x => x.StateName, y => y.MapFrom(src => src.StateName))
				.ForMember(x => x.StateCode, y => y.MapFrom(src => src.StateCode));
		}
	}
}