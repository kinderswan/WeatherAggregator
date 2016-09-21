using System.Globalization;
using System.Net;
using log4net;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class CountriesRepository : RepositoryBase<CountriesCollectionModel>, ICountriesRepository
	{
		private readonly ILog log;

		public CountriesRepository()
		{
		}

		public CountriesRepository(IHttpRequestor requestor, ILog log) : base(requestor)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
		}

		public CountriesCollectionModel GetCountriesCollection()
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");

			IRestResponse<CountriesCollectionModel> response = this.GetResponseFromUrl(ApisUrlsNames.BaseCountriesUrl);
			return response.StatusCode == HttpStatusCode.OK
				? response.Data
				: default(CountriesCollectionModel);
		}
	}
}