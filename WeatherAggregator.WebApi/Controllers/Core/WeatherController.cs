using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.Core
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/weather")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherService weatherService;

        public WeatherController() { }

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        [Route("{api}/{country}/{state}/{city}")]
        public IHttpActionResult ShowWeatherWithState(string api, string country, string state, string city)
        {
            WeatherConventionModel result = this.weatherService.GetWeatherData(new CityModel()
            {
                CountryName = country,
                CityName = city,
                StateName = state
            }, api);

            return Json(Mapper.Map<WeatherConventionModel, WeatherViewModel>(result));
        }

        [HttpGet]
        [Route("{api}/{country}/{city}")]
        public IHttpActionResult ShowWeather(string api, string country, string city)
        {
            WeatherConventionModel result = this.weatherService.GetWeatherData(new CityModel
            {
                CountryName = country,
                CityName = city
            }, api);

            return Json(Mapper.Map<WeatherConventionModel, WeatherViewModel>(result));
        }

        
    }
}
