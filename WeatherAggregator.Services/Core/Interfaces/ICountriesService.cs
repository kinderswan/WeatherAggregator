using WeatherAggregator.Models.Models.Core.Countries;

namespace WeatherAggregator.Services.Core.Interfaces
{
	public interface ICountriesService
	{
		CountriesCollectionModel GetCountriesCollection();
	}
}
