using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAggregator.Repository.Interfaces
{
	public interface IWeatherRepository<out T>
	{
		T GetResponseData(string url);
	}
}
