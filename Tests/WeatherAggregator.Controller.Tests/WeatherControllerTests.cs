using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi;
using WeatherAggregator.WebApi.Controllers.Core;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.Controller.Tests
{
    [TestClass]
    public class WeatherControllerTest
    {
        private Mock<IWeatherService> weatherServiceMock;

        private WeatherController weatherController;

        private readonly WeatherConventionModel response = new WeatherConventionModel
        {
            Temperature = 20
        };

        [TestInitialize]
        public void Initialize()
        {
            this.weatherServiceMock = new Mock<IWeatherService>();
            this.weatherController = new WeatherController(this.weatherServiceMock.Object);
            AutoMapperConfig.Configure();
        }
    }
}
