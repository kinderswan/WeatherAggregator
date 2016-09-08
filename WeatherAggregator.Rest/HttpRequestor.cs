using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Rest
{
	public class HttpRequestor : IHttpRequestor, IDisposable
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(HttpRequestor).Name);

        private readonly HttpClient httpClient;

		public HttpRequestor() { }

		public HttpRequestor(HttpClient client)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "Ctrl has been called");
			this.httpClient = client;
		}

		public IRestResponse<TResponse> PerformRequest<TResponse>(string url, HttpMethod method)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "PerformRequest has been called with {0} and {1} method", url, method.ToString());

            if (string.IsNullOrEmpty(url))
		    {
                log.ErrorFormat(CultureInfo.InvariantCulture, "PerformRequest");
		        throw new ArgumentException(url, "url");
		    }

			HttpResponseMessage result = Task.Run(() => this.ExecuteMethod(url, method)).Result;
			return new RestResponse<TResponse>(result);
		}

		public void Dispose()
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "HttpRequestor has been disposed");
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (httpClient != null)
				{
					httpClient.Dispose();
				}
			}
		}

		private async Task<HttpResponseMessage> ExecuteMethod(string url, HttpMethod method)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "ExecuteMethod");

            switch (method)
			{
				case HttpMethod.Get:
					return await this.httpClient.GetAsync(url);
				case HttpMethod.Delete:
				case HttpMethod.Post:
				case HttpMethod.Put:
				default:
                    log.ErrorFormat(CultureInfo.InvariantCulture, "ExecuteMethod");
                    throw new NotImplementedException("Method is not implemented");
			}
		}
	}
}
