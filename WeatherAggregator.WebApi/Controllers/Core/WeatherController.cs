using System.Globalization;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using log4net;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.Core
{
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api/weather")]
	public class WeatherController : ApiController
	{
		private readonly ILog log;

		private readonly IWeatherService weatherService;

		public WeatherController()
		{
		}

		public WeatherController(IWeatherService weatherService, ILog log)
		{
			this.log = log;
			log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.weatherService = weatherService;
		}

		[HttpGet]
		[Route("{api}/{country}/{state}/{city}")]
		public IHttpActionResult ShowWeatherWithState(string api, string country, string state, string city)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with api '{0}', country '{1}', state '{2}', city '{3}'", api, country, state, city);

			WeatherConventionModel result = this.weatherService.GetWeatherData(new CityModel
			{
				CountryName = country,
				CityName = city,
				StateName = state
			}, api);

			return this.Json(Mapper.Map<WeatherConventionModel, WeatherViewModel>(result));
		}

		[HttpGet]
		[Route("{api}/{country}/{city}")]
		public IHttpActionResult ShowWeather(string api, string country, string city)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with api '{0}', country '{1}', city '{2}'", api, country, city);

			WeatherConventionModel result = this.weatherService.GetWeatherData(new CityModel
			{
				CountryName = country,
				CityName = city
			}, api);

			return this.Json(Mapper.Map<WeatherConventionModel, WeatherViewModel>(result));
		}
	}
}