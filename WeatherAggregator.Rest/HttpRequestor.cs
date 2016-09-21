using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using log4net;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Rest
{
	public class HttpRequestor : IHttpRequestor, IDisposable
	{
		private readonly log4net.ILog log;

		private readonly HttpClient httpClient;

		public HttpRequestor() { }

		public HttpRequestor(HttpClient client, ILog log)
		{
		    this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.httpClient = client;
		}

		public IRestResponse<TResponse> PerformRequest<TResponse>(string url, HttpMethod method)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with url '{0}', method '{1}'", url, method);

			if (string.IsNullOrEmpty(url))
			{
				log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because url was null or empty");
				throw new ArgumentException(url, "url");
			}

			HttpResponseMessage result = Task.Run(() => this.ExecuteMethod(url, method)).Result;
			return new RestResponse<TResponse>(result);
		}

		public void Dispose()
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");
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
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with url '{0}', method '{1}'", url, method);

			switch (method)
			{
				case HttpMethod.Get:
					return await this.httpClient.GetAsync(url);
				case HttpMethod.Delete:
				case HttpMethod.Post:
				case HttpMethod.Put:
				default:
					log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because such method is not implemented");
					throw new NotImplementedException("Method is not implemented");
			}
		}
	}
}
