using System.Collections.Generic;
using System.Globalization;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using log4net;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.Core
{
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api/location")]
	public class CitiesController : ApiController
	{
		private readonly ILog log;

		private readonly ICitiesService sitiesService;

		public CitiesController()
		{
		}

		public CitiesController(ICitiesService sitiesService, ILog log)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.sitiesService = sitiesService;
		}

		[HttpGet]
		[Route("getcities/{countryName}")]
		public IHttpActionResult GetCountries(string countryName)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with countryName '{0}'", countryName);

			if (string.IsNullOrEmpty(countryName))
			{
				return this.Json(new List<CityViewModel>
				{
					default(CityViewModel)
				});
			}

			CitiesCollectionModel result = this.sitiesService.GetCitiesCollection(countryName);
			return this.Json(Mapper.Map<CitiesCollectionModel, CitiesCollectionViewModel>(result).Cities);
		}

		[HttpGet]
		[Route("getcities/{countryName}/{stateName}")]
		public IHttpActionResult GetCountries(string countryName, string stateName)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with countryName '{0}', stateName '{1}'", countryName, stateName);

			if (string.IsNullOrEmpty(countryName))
			{
				return this.Json(new List<CityViewModel>
				{
					default(CityViewModel)
				});
			}

			if (string.IsNullOrEmpty(stateName))
			{
				return this.GetCountries(countryName);
			}

			CitiesCollectionModel result = this.sitiesService.GetCitiesCollection(countryName, stateName);
			return this.Json(Mapper.Map<CitiesCollectionModel, CitiesCollectionViewModel>(result).Cities);
		}
	}
}