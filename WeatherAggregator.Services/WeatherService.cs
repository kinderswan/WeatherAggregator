using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using log4net;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Repository;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.WeatherRepositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class WeatherService : IWeatherService
	{
		private readonly log4net.ILog log;

		private readonly IEnumerable<Lazy<IWeatherRepository, IRepositorySet>> repositorySetMeta;

		public WeatherService() { }

		public WeatherService(IEnumerable<Lazy<IWeatherRepository, IRepositorySet>> repositoryMeta, ILog log)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.repositorySetMeta = repositoryMeta;
		}

		public WeatherConventionModel GetWeatherData(CityModel cityModel, string resourceName)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with resourceName '{0}'", resourceName);

			IWeatherRepository repository = this.ResolveWeatherRepository(this.SelectRepositorySet(resourceName));
			return repository.GetWeatherData(cityModel);
		}

		private IWeatherRepository ResolveWeatherRepository(RepositorySet repository)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "ResolveWeatherRepository");

			Lazy<IWeatherRepository, IRepositorySet> lazy = this.repositorySetMeta.FirstOrDefault(e => e.Metadata.RepositorySet == repository);
			if (lazy == null)
			{
				log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because could not find any repository to resolve");
				throw new ArgumentException("There are no such weather apis / resolve");
			}
			return lazy.Value;
		}

		private RepositorySet SelectRepositorySet(string name)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "SelectRepositorySet");

			string resourceName = WeatherApiNames.ResourceManager.GetObject(name) as string;
			RepositorySet resultRepositorySet;
			Enum.TryParse(resourceName, true, out resultRepositorySet);
			return resultRepositorySet;
		}
	}
}
