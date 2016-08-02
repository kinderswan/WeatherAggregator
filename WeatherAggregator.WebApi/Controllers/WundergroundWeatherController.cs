using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherAggregator.Models.Models.Countries.Wunderground;
using WeatherAggregator.Services.WeatherServices.Interfaces;

namespace WeatherAggregator.WebApi.Controllers
{
	public class WundergroundWeatherController : ApiController
	{
		private readonly IWundergroundWeatherService weatherService;

		public WundergroundWeatherController() { }

		public WundergroundWeatherController(IWundergroundWeatherService weatherService)
		{
			this.weatherService = weatherService;
		}

		[HttpGet]
		[Route("api/showmeweather")]
		public IHttpActionResult ShowSomeWeather()
		{
			var result = this.weatherService.GetWeather(new CityModel()
			{
				CountryName = "Belarus",
				CityName = "Minsk"
			});
			return Json(result);
		}
	}
}
