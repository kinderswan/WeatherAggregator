using System;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Infrastructure
{
	public abstract class RepositoryBase<T> where T: class
	{
		private readonly IHttpRequestor httpRequestor;

		protected RepositoryBase() { }

		protected RepositoryBase(IHttpRequestor requestor)
		{
			this.httpRequestor = requestor;
		}

		public virtual T GetResponseFromUrl(string url)
		{
			return this.httpRequestor.PerformRequest<T>(url, HttpMethod.Get).Data;
		}
	}
}
