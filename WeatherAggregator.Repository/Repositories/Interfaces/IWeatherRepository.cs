using System;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Repository.Infrastructure.Interfaces;

namespace WeatherAggregator.Repository.Repositories.Interfaces
{
	public interface IWeatherRepository<T> : IRepository<T> where T : class
	{
		WeatherConventionModel GetWeatherData(string url, Func<T, WeatherConventionModel> mapper);
	}
}
