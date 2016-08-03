using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Infrastructure.Interfaces;

namespace WeatherAggregator.Repository.Repositories.Interfaces
{
	public interface ICountriesRepository : IRepository<CountriesCollectionModel>
	{
		CountriesCollectionModel GetCountriesCollection();
	}
}
