using System.Diagnostics;
using System.Globalization;
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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ImageController).Name);

        private readonly IWeatherService weatherService;

        public WeatherController() { }

        public WeatherController(IWeatherService weatherService)
        {
            log.InfoFormat(CultureInfo.InvariantCulture, "Ctrl has been called");
            this.weatherService = weatherService;
        }

        [HttpGet]
        [Route("{api}/{country}/{state}/{city}")]
        public IHttpActionResult ShowWeatherWithState(string api, string country, string state, string city)
        {
            log.InfoFormat(CultureInfo.InvariantCulture, "ShowWeatherWithState");

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
            log.InfoFormat(CultureInfo.InvariantCulture, "ShowWeather");

            WeatherConventionModel result = this.weatherService.GetWeatherData(new CityModel
            {
                CountryName = country,
                CityName = city
            }, api);

            return Json(Mapper.Map<WeatherConventionModel, WeatherViewModel>(result));
        }

        
    }
}
