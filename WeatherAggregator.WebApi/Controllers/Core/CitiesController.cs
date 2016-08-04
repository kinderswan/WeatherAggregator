using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.Core
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api/location")]
	public class CitiesController : ApiController
	{
		private readonly ICitiesService sitiesService;

		public CitiesController() { }

		public CitiesController(ICitiesService sitiesService)
		{
			this.sitiesService = sitiesService;
		}

		[HttpGet]
		[Route("getcities/{countryName}")]
		public IHttpActionResult GetCountries(string countryName)
		{
			var result = this.sitiesService.GetCitiesCollection(countryName);
			return Json(Mapper.Map<CitiesCollectionModel, CitiesCollectionViewModel>(result).Cities);
		}

		[HttpGet]
		[Route("getcities/{countryName}/{stateName}")]
		public IHttpActionResult GetCountries(string countryName, string stateName)
		{
			var result = this.sitiesService.GetCitiesCollection(countryName, stateName);
			return Json(Mapper.Map<CitiesCollectionModel, CitiesCollectionViewModel>(result).Cities);
		}
	}
}
