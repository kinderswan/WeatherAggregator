using System.Net;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class CountriesRepository : RepositoryBase<CountriesCollectionModel>, ICountriesRepository
	{
		public CountriesRepository() { }

		public CountriesRepository(IHttpRequestor requestor) : base(requestor) { }

		public CountriesCollectionModel GetCountriesCollection()
		{
			var response = base.GetResponseFromUrl(ApisUrlsNames.BaseCountriesUrl);
			return response.StatusCode == HttpStatusCode.OK
				? response.Data
				: default(CountriesCollectionModel);
		}
	}
}
