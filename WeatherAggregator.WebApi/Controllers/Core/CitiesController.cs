﻿using System.Collections.Generic;
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
            if (string.IsNullOrEmpty(countryName))
            {
                return Json(new List<CityViewModel>
                {
                    default(CityViewModel)

                });
            }

            CitiesCollectionModel result = this.sitiesService.GetCitiesCollection(countryName);
            return Json(Mapper.Map<CitiesCollectionModel, CitiesCollectionViewModel>(result).Cities);
        }

        [HttpGet]
        [Route("getcities/{countryName}/{stateName}")]
        public IHttpActionResult GetCountries(string countryName, string stateName)
        {
            if (string.IsNullOrEmpty(countryName))
            {
                return Json(new List<CityViewModel>
                {
                    default(CityViewModel)

                });
            }

            if (string.IsNullOrEmpty(stateName))
            {
                return this.GetCountries(countryName);
            }

            CitiesCollectionModel result = this.sitiesService.GetCitiesCollection(countryName, stateName);
            return Json(Mapper.Map<CitiesCollectionModel, CitiesCollectionViewModel>(result).Cities);
        }
    }
}
