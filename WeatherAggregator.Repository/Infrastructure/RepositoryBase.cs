using System.Globalization;
using log4net;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Infrastructure
{
	public abstract class RepositoryBase<T> where T : class
	{
		private readonly IHttpRequestor httpRequestor;
		private readonly ILog log = LogManager.GetLogger(typeof (RepositoryBase<T>).Name);

		protected RepositoryBase()
		{
		}

		protected RepositoryBase(IHttpRequestor requestor)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.httpRequestor = requestor;
		}

		public virtual IRestResponse<T> GetResponseFromUrl(string url)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with url '{0}'", url);
			return this.httpRequestor.PerformRequest<T>(url, HttpMethod.Get);
		}
	}
}