using AutoMapper;
using WeatherAggregator.WebApi.Mappings.WeatherModels;

namespace WeatherAggregator.WebApi
{
	public class AutoMapperConfig
	{
		public static void Configure()
		{
			Mapper.Initialize(x =>
				x.AddProfile<WundergroundMapping>());
		}
	}
}