using System.Globalization;
using System.Net;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class CountriesRepository : RepositoryBase<CountriesCollectionModel>, ICountriesRepository
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CountriesRepository).Name);

        public CountriesRepository() { }

	    public CountriesRepository(IHttpRequestor requestor) : base(requestor)
	    {
	        log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
	    }

		public CountriesCollectionModel GetCountriesCollection()
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");

			IRestResponse<CountriesCollectionModel> response = base.GetResponseFromUrl(ApisUrlsNames.BaseCountriesUrl);
			return response.StatusCode == HttpStatusCode.OK
				? response.Data
				: default(CountriesCollectionModel);
		}
	}
}
