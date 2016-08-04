using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Repository.Infrastructure.Interfaces;

namespace WeatherAggregator.Repository.Repositories.Interfaces
{
	public interface ICitiesRepository : IRepository<CitiesContainerResponse>
	{
		CitiesCollectionModel GetCitiesCollection(string countryName);

		CitiesCollectionModel GetCitiesCollection(string countryName, string stateName);
	}
}
