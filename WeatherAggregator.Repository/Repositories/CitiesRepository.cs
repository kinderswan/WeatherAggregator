using System;
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
            if (string.IsNullOrEmpty(countryName))
            {
                throw new ArgumentException(countryName, "countryName");
            }

            string url = string.Format(ApisUrlsNames.BaseCitiesUrl, countryName);
			IRestResponse<CitiesContainerResponse> response = base.GetResponseFromUrl(url);

			return response.Data == null
				? default(CitiesCollectionModel)
				: (response.StatusCode == HttpStatusCode.OK
				? response.Data.CitiesContainer
				: default(CitiesCollectionModel));
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName, string stateName)
		{
		    if (string.IsNullOrEmpty(countryName))
		    {
		        throw new ArgumentException(countryName, "countryName");
		    }

            if (string.IsNullOrEmpty(stateName))
            {
                throw new ArgumentException(stateName, "stateName");
            }

            string url = string.Format(ApisUrlsNames.BaseStateCitiesUrl, countryName, stateName);
			IRestResponse<CitiesContainerResponse> response = base.GetResponseFromUrl(url);
			return response.Data == null
				? default(CitiesCollectionModel)
				: (response.StatusCode == HttpStatusCode.OK
				? response.Data.CitiesContainer
				: default(CitiesCollectionModel));
		}
	}
}
