using System.Web.Http;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.Services.WeatherServices.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.WeatherControllers
{
	[RoutePrefix("api/wunderground")]
	public class WundergroundWeatherController : ApiController
	{
		private readonly IWundergroundWeatherService weatherService;

		public WundergroundWeatherController() { }

		public WundergroundWeatherController(IWundergroundWeatherService weatherService)
		{
			this.weatherService = weatherService;
		}

		[HttpGet]
		[Route("{country}/{state}/{city}")]
		public IHttpActionResult ShowWeatherWithState(string country, string state, string city)
		{
			var result = this.weatherService.GetWeather(new CityModel()
			{
				CountryName = country,
				CityName = city,
				StateName = state
			});
			
			return Json(Mapper.Map<WeatherModel, WeatherViewModel>(result));
		}

		[HttpGet]
		[Route("{country}/{city}")]
		public IHttpActionResult ShowWeather(string country, string city)
		{
			var result = this.weatherService.GetWeather(new CityModel
			{
				CountryName = country,
				CityName = city
			});

			return Json(Mapper.Map<WeatherModel, WeatherViewModel>(result));
		}
	}
}
