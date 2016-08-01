using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAggregator.Rest.Interfaces
{
	public interface IHttpRequestor
	{
		IRestResponse<TResponse> PerformRequest<TResponse>(string url, HttpMethod method);
	}
}
