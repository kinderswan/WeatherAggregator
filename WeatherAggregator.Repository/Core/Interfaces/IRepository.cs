namespace WeatherAggregator.Repository.Core.Interfaces
{
	public interface IRepository<T> where T: class
	{
		T GetResponseData(string url);
	}
}
