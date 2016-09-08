using System;
using System.Globalization;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class CitiesService : ICitiesService
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CitiesService).Name);

        private readonly ICitiesRepository citiesRepository;

		public CitiesService() { }

		public CitiesService(ICitiesRepository citiesRepository)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "Ctrl has been called");
			this.citiesRepository = citiesRepository;
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "GetCitiesCollection");

            if (string.IsNullOrEmpty(countryName))
		    {
                log.ErrorFormat(CultureInfo.InvariantCulture, "GetCitiesCollection");
                throw new ArgumentException(countryName, "countryName");
		    }

			return this.citiesRepository.GetCitiesCollection(countryName);
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName, string stateName)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "GetCitiesCollection");

            if (string.IsNullOrEmpty(countryName))
            {
                log.ErrorFormat(CultureInfo.InvariantCulture, "GetCitiesCollection");
                throw new ArgumentException(countryName, "countryName");
            }

            if (string.IsNullOrEmpty(stateName))
            {
                log.ErrorFormat(CultureInfo.InvariantCulture, "GetCitiesCollection");
                throw new ArgumentException(stateName, "stateName");
            }

            return this.citiesRepository.GetCitiesCollection(countryName, stateName);
		}
	}
}
