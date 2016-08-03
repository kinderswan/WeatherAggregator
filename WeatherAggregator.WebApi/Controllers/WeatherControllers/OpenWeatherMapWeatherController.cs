using System.Web.Http;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Services.WeatherServices.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.WeatherControllers
{
	[RoutePrefix("api/weather/openweathermap")]
	public class OpenWeatherMapWeatherController : ApiController
	{
		private readonly IOpenWeatherMapWeatherService weatherService;

		public OpenWeatherMapWeatherController() { }

		public OpenWeatherMapWeatherController(IOpenWeatherMapWeatherService weatherService)
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
			
			return Json(Mapper.Map<WeatherConventionModel, WeatherViewModel>(result));
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

			return Json(Mapper.Map<WeatherConventionModel, WeatherViewModel>(result));
		}
	}
}
