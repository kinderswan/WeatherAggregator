using WeatherAggregator.Models.Models.Core.Countries;

namespace WeatherAggregator.Services.Interfaces
{
	public interface ICountriesService
	{
		CountriesCollectionModel GetCountriesCollection();
	}
}
