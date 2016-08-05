using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class CountriesService : ICountriesService
	{
		private readonly ICountriesRepository countriesRepository;

		public CountriesService() { }

		public CountriesService(ICountriesRepository countriesRepository)
		{
			this.countriesRepository = countriesRepository;
		}

		public CountriesCollectionModel GetCountriesCollection()
		{
			return this.countriesRepository.GetCountriesCollection();
		}
	}
}
