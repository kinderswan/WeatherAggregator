using System.Globalization;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using log4net;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.Core
{
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api/location")]
	public class CountriesController : ApiController
	{
		private readonly ICountriesService countriesService;
		private readonly ILog log;

		public CountriesController()
		{
		}

		public CountriesController(ICountriesService countriesService, ILog log)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.countriesService = countriesService;
		}

		[HttpGet]
		[Route("getcountries")]
		public IHttpActionResult GetCountries()
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");
			CountriesCollectionModel result = this.countriesService.GetCountriesCollection();
			return this.Json(Mapper.Map<CountriesCollectionModel, CountriesCollectionViewModel>(result).Countries);
		}
	}
}