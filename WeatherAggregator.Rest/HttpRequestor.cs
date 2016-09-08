using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Rest
{
	public class HttpRequestor : IHttpRequestor, IDisposable
	{
		private readonly HttpClient httpClient;

		public HttpRequestor()
		{
		}

		public HttpRequestor(HttpClient client)
		{
			this.httpClient = client;
		}

		public IRestResponse<TResponse> PerformRequest<TResponse>(string url, HttpMethod method)
		{
		    if (string.IsNullOrEmpty(url))
		    {
		        throw new ArgumentException(url, "url");
		    }
			HttpResponseMessage result = Task.Run(() => this.ExecuteMethod(url, method)).Result;
			return new RestResponse<TResponse>(result);
		}

		public void Dispose()
		{
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
			switch (method)
			{
				case HttpMethod.Get:
					return await this.httpClient.GetAsync(url);
				case HttpMethod.Delete:
				case HttpMethod.Post:
				case HttpMethod.Put:
				default:
					throw new NotImplementedException("Method is not implemented");
			}
		}
	}
}
