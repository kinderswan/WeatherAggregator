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
		private readonly HttpClient httpClient;
		private readonly ILog log;

		public HttpRequestor()
		{
		}

		public HttpRequestor(HttpClient client, ILog log)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.httpClient = client;
		}

		public void Dispose()
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		public IRestResponse<TResponse> PerformRequest<TResponse>(string url, HttpMethod method)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with url '{0}', method '{1}'", url, method);

			if (string.IsNullOrEmpty(url))
			{
				this.log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because url was null or empty");
				throw new ArgumentException(url, "url");
			}

			HttpResponseMessage result = Task.Run(() => this.ExecuteMethod(url, method)).Result;
			return new RestResponse<TResponse>(result);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.httpClient != null)
				{
					this.httpClient.Dispose();
				}
			}
		}

		private async Task<HttpResponseMessage> ExecuteMethod(string url, HttpMethod method)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with url '{0}', method '{1}'", url, method);

			switch (method)
			{
				case HttpMethod.Get:
					return await this.httpClient.GetAsync(url);
				default:
					this.log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because such method is not implemented");
					throw new NotImplementedException("Method is not implemented");
			}
		}
	}
}