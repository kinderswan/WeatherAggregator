using System.Globalization;
using log4net;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class CountriesService : ICountriesService
	{
		private readonly log4net.ILog log;

		private readonly ICountriesRepository countriesRepository;

		public CountriesService() { }

		public CountriesService(ICountriesRepository countriesRepository, ILog log)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.countriesRepository = countriesRepository;
		}

		public CountriesCollectionModel GetCountriesCollection()
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");
			return this.countriesRepository.GetCountriesCollection();
		}
	}
}
