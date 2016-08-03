using System.Web.Http;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Services.Core.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.Core
{
	[RoutePrefix("api/cities")]
	public class CitiesController : ApiController
	{
		private readonly ICitiesService sitiesService;

		public CitiesController() { }

		public CitiesController(ICitiesService sitiesService)
		{
			this.sitiesService = sitiesService;
		}

		[HttpGet]
		[Route("{countryName}/getcities")]
		public IHttpActionResult GetCountries(string countryName)
		{
			var result = this.sitiesService.GetCitiesCollection(countryName);
			return Json(Mapper.Map<CitiesCollectionModel, CitiesCollectionViewModel>(result));
		}

		[HttpGet]
		[Route("{countryName}/{stateName}/getcities")]
		public IHttpActionResult GetCountries(string countryName, string stateName)
		{
			var result = this.sitiesService.GetCitiesCollection(countryName);
			return Json(Mapper.Map<CitiesCollectionModel, CitiesCollectionViewModel>(result));
		}
	}
}
