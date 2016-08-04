using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class CitiesRepository : RepositoryBase<CitiesContainerResponse>, ICitiesRepository
	{
		private const string BaseCitiesUrl = @"http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}.json";

		private const string BaseStateCitiesUrl = @"http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}/{1}.json";

		public CitiesRepository() { }

		public CitiesRepository(IHttpRequestor requestor) : base(requestor) { }
		
		public CitiesCollectionModel GetCitiesCollection(string countryName)
		{
			string url = string.Format(CitiesRepository.BaseCitiesUrl, countryName);
			return base.GetResponseFromUrl(url).CitiesContainer;
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName, string stateName)
		{
			string url = string.Format(CitiesRepository.BaseStateCitiesUrl, countryName, stateName);
			return base.GetResponseFromUrl(url).CitiesContainer;
		}
	}
}
