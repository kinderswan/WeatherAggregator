using System;
using System.Globalization;
using System.Net;
using log4net;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class CitiesRepository : RepositoryBase<CitiesContainerResponse>, ICitiesRepository
	{
		private readonly ILog log;

		public CitiesRepository()
		{
		}

		public CitiesRepository(IHttpRequestor requestor, ILog log)
			: base(requestor)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with countryName '{0}'", countryName);

			if (string.IsNullOrEmpty(countryName))
			{
				this.log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because countryName was null or empty");
				throw new ArgumentException(countryName, "countryName");
			}

			string url = string.Format(ApisUrlsNames.BaseCitiesUrl, countryName);
			IRestResponse<CitiesContainerResponse> response = this.GetResponseFromUrl(url);

			return response.Data == null
				? default(CitiesCollectionModel)
				: (response.StatusCode == HttpStatusCode.OK
					? response.Data.CitiesContainer
					: default(CitiesCollectionModel));
		}

		public CitiesCollectionModel GetCitiesCollection(string countryName, string stateName)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with countryName '{0}', stateName '{1}'", countryName, stateName);

			if (string.IsNullOrEmpty(countryName))
			{
				this.log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because countryName was null or empty");

				throw new ArgumentException(countryName, "countryName");
			}

			if (string.IsNullOrEmpty(stateName))
			{
				this.log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because stateName was null or empty");

				throw new ArgumentException(stateName, "stateName");
			}

			string url = string.Format(ApisUrlsNames.BaseStateCitiesUrl, countryName, stateName);
			IRestResponse<CitiesContainerResponse> response = this.GetResponseFromUrl(url);
			return response.Data == null
				? default(CitiesCollectionModel)
				: (response.StatusCode == HttpStatusCode.OK
					? response.Data.CitiesContainer
					: default(CitiesCollectionModel));
		}
	}
}