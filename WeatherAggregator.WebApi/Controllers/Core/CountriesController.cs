using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.Core
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api/location")]
	public class CountriesController : ApiController
	{
		private readonly ICountriesService countriesService;

		public CountriesController() { }

		public CountriesController(ICountriesService countriesService)
		{
			this.countriesService = countriesService;
		}

		[HttpGet]
		[Route("getcountries")]
		public IHttpActionResult GetCountries()
		{
			var result = this.countriesService.GetCountriesCollection();
			return Json(Mapper.Map<CountriesCollectionModel, CountriesCollectionViewModel>(result).Countries);
		}
	}
}
