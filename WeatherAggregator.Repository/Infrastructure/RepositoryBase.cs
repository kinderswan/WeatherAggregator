using System.Globalization;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Infrastructure
{
	public abstract class RepositoryBase<T> where T : class
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(RepositoryBase<T>).Name);

        private readonly IHttpRequestor httpRequestor;

		protected RepositoryBase()
		{
			
		}

		protected RepositoryBase(IHttpRequestor requestor)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "Ctrl has been called");
			this.httpRequestor = requestor;
		}

		public virtual IRestResponse<T> GetResponseFromUrl(string url)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "GetResponseFromUrl has bee called");
			return this.httpRequestor.PerformRequest<T>(url, HttpMethod.Get);
		}
	}
}
