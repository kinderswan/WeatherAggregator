using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class CountriesRepository : RepositoryBase<CountriesCollectionModel>, ICountriesRepository
	{
		private const string BaseCountriesUrl = @"https://api.theprintful.com/countries";

		public CountriesRepository() { }

		public CountriesRepository(IHttpRequestor requestor) : base(requestor) { }

		public CountriesCollectionModel GetCountriesCollection()
		{
			return base.GetResponseFromUrl(CountriesRepository.BaseCountriesUrl);
		}
	}
}
