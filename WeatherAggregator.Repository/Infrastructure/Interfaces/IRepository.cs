namespace WeatherAggregator.Repository.Infrastructure.Interfaces
{
	public interface IRepository<T> where T: class
	{
		T GetResponseData(string url);
	}
}
