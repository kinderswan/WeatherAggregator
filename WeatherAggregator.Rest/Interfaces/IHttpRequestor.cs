namespace WeatherAggregator.Rest.Interfaces
{
	public interface IHttpRequestor
	{
		IRestResponse<TResponse> PerformRequest<TResponse>(string url, HttpMethod method);
	}
}