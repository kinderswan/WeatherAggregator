using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using log4net;
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

        private Mock<ILog> logMock; 

        private WeatherController weatherController;

        private readonly WeatherConventionModel response = new WeatherConventionModel
        {
            Temperature = 20
        };

        [TestInitialize]
        public void Initialize()
        {
            this.weatherServiceMock = new Mock<IWeatherService>();
            this.logMock = new Mock<ILog>();
            this.weatherController = new WeatherController(this.weatherServiceMock.Object, this.logMock.Object);
            AutoMapperConfig.Configure();
        }

        [TestMethod, TestCategory("Controllers")]
        public void GetWeather_ShouldReturnWeatherViewModel()
        {
            this.weatherServiceMock.Setup(x => x.GetWeatherData(It.Is<CityModel>(k => k.CountryName == "CountryName" && k.CityName == "CityName"),
                It.Is<string>(y => y == "wunderground")))
                .Returns(this.response).Verifiable();

            using (this.weatherController)
            {
                var result = this.weatherController.ShowWeather("wunderground", "CountryName", "CityName") as JsonResult<WeatherViewModel>;
                Assert.IsNotNull(result);
                Assert.AreEqual(20, result.Content.Temperature);
            }

            this.weatherServiceMock.VerifyAll();
        }
    }
}
