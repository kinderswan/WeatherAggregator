using AutoMapper;
using WeatherAggregator.WebApi.Mappings;
using WeatherAggregator.WebApi.Mappings.WeatherModels;

namespace WeatherAggregator.WebApi
{
	public class AutoMapperConfig
	{
		public static void Configure()
		{
			Mapper.Initialize(x =>
			{
				x.AddProfile<WundergroundConventionMapping>();
				x.AddProfile<ImageMapping>();
				x.AddProfile<WeatherMapping>();
				x.AddProfile<CountriesMapping>();
			});
		}
	}
}