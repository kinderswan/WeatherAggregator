using AutoMapper;
using WeatherAggregator.WebApi.Mappings;
using WeatherAggregator.WebApi.Mappings.WeatherModelsMappings;

namespace WeatherAggregator.WebApi
{
	public class AutoMapperConfig
	{
		public static void Configure()
		{
			Mapper.Initialize(x =>
			{
				// Transform third-party weather api models to default
				x.AddProfile<WundergroundConventionMapping>();
				x.AddProfile<OpenWeatherMapConventionMapping>();

				x.AddProfile<ImageMapping>();
				x.AddProfile<WeatherMapping>();
				x.AddProfile<CountriesMapping>();
				x.AddProfile<CitiesMapping>();
			});
		}
	}
}