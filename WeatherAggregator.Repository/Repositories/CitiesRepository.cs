using System.Net;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class CitiesRepository : RepositoryBase<CitiesContainerResponse>, ICitiesRepository
	{
		public CitiesRepository() { }

		public CitiesRepository(IHttpRequestor requestor) : base(requestor) { }
		
		public CitiesCollectionModel GetCitiesCollection(string countryName)
		{
			string url = string.Format(ApisUrlsNames.BaseCitiesUrl, countryName);
			var response = base.GetResponseFromUrl(url);
			return response.StatusCode == HttpStatusCode.OK 
				? response.Data.CitiesContainer 
				: default(CitiesCollectionModel);
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName, string stateName)
		{
			string url = string.Format(ApisUrlsNames.BaseStateCitiesUrl, countryName, stateName);
			var response = base.GetResponseFromUrl(url);
			return response.StatusCode == HttpStatusCode.OK
				? response.Data.CitiesContainer
				: default(CitiesCollectionModel);
		}
	}
}
