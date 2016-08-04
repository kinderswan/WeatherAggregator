using System;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class WeatherRepository<T> : RepositoryBase<T>, IWeatherRepository<T> where T : class
	{
		public WeatherRepository() { }

		public WeatherRepository(IHttpRequestor httpRequestor) : base(httpRequestor) { }

		public WeatherConventionModel GetWeatherData(string url, Func<T, WeatherConventionModel> mapper)
		{
			return mapper(base.GetResponseFromUrl(url));
		}

		
	}
}
