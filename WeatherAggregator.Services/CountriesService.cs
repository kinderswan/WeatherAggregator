using System.Globalization;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class CountriesService : ICountriesService
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CountriesService).Name);

        private readonly ICountriesRepository countriesRepository;

		public CountriesService() { }

		public CountriesService(ICountriesRepository countriesRepository)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "Ctrl has been called");
			this.countriesRepository = countriesRepository;
		}

		public CountriesCollectionModel GetCountriesCollection()
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "GetCountriesCollection");
            return this.countriesRepository.GetCountriesCollection();
		}
	}
}
