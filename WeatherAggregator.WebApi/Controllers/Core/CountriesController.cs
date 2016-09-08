using System.Globalization;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.Core
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/location")]
    public class CountriesController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CountriesController).Name);

        private readonly ICountriesService countriesService;

        public CountriesController() { }

        public CountriesController(ICountriesService countriesService)
        {
            log.InfoFormat(CultureInfo.InvariantCulture, "Ctrl has been called");
            this.countriesService = countriesService;
        }

        [HttpGet]
        [Route("getcountries")]
        public IHttpActionResult GetCountries()
        {
            log.InfoFormat(CultureInfo.InvariantCulture, "GetCountries");
            CountriesCollectionModel result = this.countriesService.GetCountriesCollection();
            return Json(Mapper.Map<CountriesCollectionModel, CountriesCollectionViewModel>(result).Countries);
        }
    }
}
