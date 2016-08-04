using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class CitiesService : ICitiesService
	{
		private readonly ICitiesRepository citiesRepository;

		public CitiesService() { }

		public CitiesService(ICitiesRepository citiesRepository)
		{
			this.citiesRepository = citiesRepository;
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName)
		{
			return this.citiesRepository.GetCitiesCollection(countryName);
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName, string stateName)
		{
			return this.citiesRepository.GetCitiesCollection(countryName, stateName);
		}
	}
}
