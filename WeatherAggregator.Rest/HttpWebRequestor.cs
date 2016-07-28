using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Rest
{
	public class HttpWebRequestor<T> : IHttpWebRequestor<T> where T : class
	{
		private WebRequest webRequest;

		public HttpWebRequestor()
		{

		}

		public T PerformRequest(string url, HttpMethod method)
		{
			if (string.IsNullOrEmpty(url))
			{
				throw new ArgumentNullException(url);
			}

			this.webRequest = this.BuildRequest(url, method);
		}

		private WebRequest BuildRequest(string url, HttpMethod method)
		{
			
			this.webRequest = WebRequest.Create(url);
			this.webRequest.Method = CreateMethod(method);

			return this.webRequest;
		}

		private string CreateMethod(HttpMethod method)
		{
			switch (method)
			{
				case HttpMethod.Get:
					return "Get";
				case HttpMethod.Delete:
					return "Delete";
				case HttpMethod.Post:
					return "Post";
				case HttpMethod.Put:
					return "Put";
			}

			throw new NotImplementedException("Method is not implemented");
		}
	}
}
