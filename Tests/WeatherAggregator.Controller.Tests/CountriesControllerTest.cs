using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi;
using WeatherAggregator.WebApi.Controllers.Core;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.Controller.Tests
{
    [TestClass]
    public class CountriesControllerTest
    {
        private Mock<ICountriesService> CountriesServiceMock;

        private CountriesController CountriesController;

        private readonly CountriesCollectionModel response = new CountriesCollectionModel()
        {
            Countries = new List<CountryModel>
            {
                new CountryModel
                {
                    CountryName = "CountryName"
                }
            }
        };

        [TestInitialize]
        public void Initialize()
        {
            this.CountriesServiceMock = new Mock<ICountriesService>();
            this.CountriesController = new CountriesController(this.CountriesServiceMock.Object);
            AutoMapperConfig.Configure();
        }

        [TestMethod, TestCategory("Controllers")]
        public void GetCountries_ShouldReturnCountriesViewModel()
        {
            this.CountriesServiceMock.Setup(x => x.GetCountriesCollection())
                .Returns(this.response).Verifiable();

            using (this.CountriesController)
            {
                var result = this.CountriesController.GetCountries() as JsonResult<List<CountryViewModel>>;
                Assert.IsNotNull(result);
                Assert.AreEqual("CountryName", result.Content.FirstOrDefault().CountryName);
            }

            this.CountriesServiceMock.VerifyAll();
        }
    }
}
