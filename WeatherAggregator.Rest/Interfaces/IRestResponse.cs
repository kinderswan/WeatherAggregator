using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAggregator.Rest.Interfaces
{
	public interface IRestResponse<out T>
	{
		HttpStatusCode StatusCode { get; }

		T Data { get; }
	}
}
