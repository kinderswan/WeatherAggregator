using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Repository.Interfaces;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository
{
	public class WeatherRepository<T> : IWeatherRepository<T>
	{
		private readonly IHttpRequestor httpRequestor;

		public WeatherRepository(IHttpRequestor requestor)
		{
			this.httpRequestor = requestor;
		}

		public T GetResponseData(string url)
		{
			return this.httpRequestor.PerformRequest<T>(url, HttpMethod.Get).Data;
		}
	}
}
