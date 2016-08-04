using WeatherAggregator.Models.Models.Core.Cities;

namespace WeatherAggregator.Services.Core.Interfaces
{
	public interface ICitiesService
	{
		CitiesCollectionModel GetCitiesCollection(string countryName);

		CitiesCollectionModel GetCitiesCollection(string countryName, string stateName);
	}
}
