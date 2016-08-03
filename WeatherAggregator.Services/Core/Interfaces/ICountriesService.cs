using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Models.Models.Core.Countries;

namespace WeatherAggregator.Services.Core.Interfaces
{
	public interface ICountriesService
	{
		CountriesCollectionModel GetCountriesCollection();
	}
}
