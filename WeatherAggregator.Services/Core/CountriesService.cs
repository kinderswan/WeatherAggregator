using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.Core.Interfaces;

namespace WeatherAggregator.Services.Core
{
	public class CountriesService : ICountriesService
	{
		private readonly ICountriesRepository countriesRepository;

		public CountriesService() { }

		public CountriesService(ICountriesRepository countriesRepository)
		{
			this.countriesRepository = countriesRepository;
		}

		public CountriesCollectionModel GetCountriesCollection()
		{
			return this.countriesRepository.GetCountriesCollection();
		}
	}
}
