using System;
using System.Collections.Generic;
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
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi;
using WeatherAggregator.WebApi.Controllers.Core;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.Controller.Tests
{
	[TestClass]
	public class CitiesControllerTest
	{
		private Mock<ICitiesService> citiesServiceMock;

		private Mock<ILog> logMock;

		private CitiesController citiesController;

		private readonly CitiesCollectionModel response = new CitiesCollectionModel()
		{
			Cities = new List<CityModel>
			{
				new CityModel
				{
					CountryName = "CountryName",
					CityName = "CityName"
				}
			}
		};

		[TestInitialize]
		public void Initialize()
		{
			this.citiesServiceMock = new Mock<ICitiesService>();
            this.logMock = new Mock<ILog>();
			this.citiesController = new CitiesController(this.citiesServiceMock.Object, this.logMock.Object);
			AutoMapperConfig.Configure();
		}

	    [TestMethod, TestCategory("Controllers")]
	    public void GetCountries_ShouldReturnCitiesViewModel()
	    {
	        this.citiesServiceMock.Setup(x => x.GetCitiesCollection(It.Is<string>(y => y == "CountryName")))
	            .Returns(this.response).Verifiable();

            using (this.citiesController)
            {
                var result = this.citiesController.GetCountries("CountryName") as JsonResult<List<CityViewModel>>;
                Assert.IsNotNull(result);
                Assert.AreEqual("CityName", result.Content.FirstOrDefault().CityName);
	        }

            this.citiesServiceMock.VerifyAll();
	    }

        [TestMethod, TestCategory("Controllers")]
        public void GetCountriesStates_ShouldReturnCitiesViewModel()
        {
            this.citiesServiceMock.Setup(x => x.GetCitiesCollection(It.Is<string>(y => y == "CountryName"), It.Is<string>(z => z == "StateName")))
                .Returns(this.response).Verifiable();

            using (this.citiesController)
            {
                var result = this.citiesController.GetCountries("CountryName","StateName") as JsonResult<List<CityViewModel>>;
                Assert.IsNotNull(result);
                Assert.AreEqual("CityName", result.Content.FirstOrDefault().CityName);
            }

            this.citiesServiceMock.VerifyAll();
        }
        
    }
}
