using System;
using System.Globalization;
using System.Net;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class CitiesRepository : RepositoryBase<CitiesContainerResponse>, ICitiesRepository
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CitiesRepository).Name);

        public CitiesRepository() { }

	    public CitiesRepository(IHttpRequestor requestor) : base(requestor)
	    {
	        log.InfoFormat(CultureInfo.InvariantCulture, "Ctrl has been called");
	    }

		public CitiesCollectionModel GetCitiesCollection(string countryName)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "GetCitiesCollection has been called");

            if (string.IsNullOrEmpty(countryName))
            {
                log.ErrorFormat(CultureInfo.InvariantCulture, "GetCitiesCollection has been called with countryName: {0}", countryName);
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
            log.InfoFormat(CultureInfo.InvariantCulture, "GetCitiesCollection has been called");

            if (string.IsNullOrEmpty(countryName))
		    {
                log.ErrorFormat(CultureInfo.InvariantCulture, "GetCitiesCollection has been called with countryName: {0}", countryName);

                throw new ArgumentException(countryName, "countryName");
		    }

            if (string.IsNullOrEmpty(stateName))
            {
                log.ErrorFormat(CultureInfo.InvariantCulture, "GetCitiesCollection has been called with stateName: {0}", stateName);

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
