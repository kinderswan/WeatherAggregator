using System.Net;

namespace WeatherAggregator.Rest.Interfaces
{
	public interface IRestResponse<out T>
	{
		HttpStatusCode StatusCode { get; }

		T Data { get; }
	}
}