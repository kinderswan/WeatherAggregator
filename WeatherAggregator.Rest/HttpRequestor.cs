using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Rest
{
	public class HttpRequestor : IHttpRequestor
	{
		private readonly HttpClient httpClient;

		public HttpRequestor()
		{
			this.httpClient = new HttpClient();
		}

		public IRestResponse<TResponse> PerformRequest<TResponse>(string url, HttpMethod method)
		{
			var result = Task.Run(() => this.ExecuteMethod(url, method)).Result;
			return new RestResponse<TResponse>(result);
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
