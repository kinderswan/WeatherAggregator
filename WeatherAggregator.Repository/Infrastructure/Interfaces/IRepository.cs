using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Infrastructure.Interfaces
{
	public interface IRepository<out T> where T : class
	{
		IRestResponse<T> GetResponseFromUrl(string url);
	}
}