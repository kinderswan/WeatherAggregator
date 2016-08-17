using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.WeatherRepositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class WeatherService : IWeatherService
	{
		private readonly IEnumerable<Lazy<IWeatherRepository, IRepositorySet>> repositorySetMeta;

		public WeatherService() { }

		public WeatherService(IEnumerable<Lazy<IWeatherRepository, IRepositorySet>> repositoryMeta)
		{
			this.repositorySetMeta = repositoryMeta;
		}

		public WeatherConventionModel GetWeatherData(CityModel cityModel, string resourceName)
		{
			IWeatherRepository repository = this.ResolveWeatherRepository(this.SelectRepositorySet(resourceName));
			return repository.GetWeatherData(cityModel);
		}

		private IWeatherRepository ResolveWeatherRepository(RepositorySet repository)
		{
			Lazy<IWeatherRepository, IRepositorySet> lazy = this.repositorySetMeta.FirstOrDefault(e => e.Metadata.RepositorySet == repository);
			if (lazy == null)
			{
				throw new ArgumentException("There are no such weather apis / resolve");
			}
			return lazy.Value;
		}

		private RepositorySet SelectRepositorySet(string name)
		{
			switch (name.ToLowerInvariant())
			{
				case "wunderground": return RepositorySet.Wunderground;
				case "openweathermap": return RepositorySet.OpenWeatherMap;
			}

			throw new ArgumentException("There are no such weather apis / select");
		}
	}
}
