﻿using System;
using System.Globalization;
using log4net;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class CitiesService : ICitiesService
	{
		private readonly ICitiesRepository citiesRepository;
		private readonly ILog log;

		public CitiesService()
		{
		}

		public CitiesService(ICitiesRepository citiesRepository, ILog log)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.citiesRepository = citiesRepository;
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with countryName '{0}'", countryName);

			if (string.IsNullOrEmpty(countryName))
			{
				this.log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because countryName was null or empty");
				throw new ArgumentException(countryName, "countryName");
			}

			return this.citiesRepository.GetCitiesCollection(countryName);
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName, string stateName)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with countryName '{0}', stateName '{1}'", countryName, stateName);

			if (string.IsNullOrEmpty(countryName))
			{
				this.log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because countryName was null or empty");
				throw new ArgumentException(countryName, "countryName");
			}

			if (string.IsNullOrEmpty(stateName))
			{
				this.log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because stateName was null or empty");
				throw new ArgumentException(stateName, "stateName");
			}

			return this.citiesRepository.GetCitiesCollection(countryName, stateName);
		}
	}
}