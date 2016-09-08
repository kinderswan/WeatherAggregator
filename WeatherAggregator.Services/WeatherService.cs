using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(WeatherService).Name);

        private readonly IEnumerable<Lazy<IWeatherRepository, IRepositorySet>> repositorySetMeta;

		public WeatherService() { }

		public WeatherService(IEnumerable<Lazy<IWeatherRepository, IRepositorySet>> repositoryMeta)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "Ctrl has been called");
			this.repositorySetMeta = repositoryMeta;
		}

		public WeatherConventionModel GetWeatherData(CityModel cityModel, string resourceName)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "GetWeatherData");

            IWeatherRepository repository = this.ResolveWeatherRepository(this.SelectRepositorySet(resourceName));
			return repository.GetWeatherData(cityModel);
		}

		private IWeatherRepository ResolveWeatherRepository(RepositorySet repository)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "ResolveWeatherRepository");

            Lazy<IWeatherRepository, IRepositorySet> lazy = this.repositorySetMeta.FirstOrDefault(e => e.Metadata.RepositorySet == repository);
			if (lazy == null)
			{
                log.ErrorFormat(CultureInfo.InvariantCulture, "ResolveWeatherRepository");
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
