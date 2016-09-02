using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
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

		private CitiesController citiesController;

		private CitiesCollectionModel response = new CitiesCollectionModel()
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
			this.citiesController = new CitiesController(this.citiesServiceMock.Object);
			AutoMapperConfig.Configure();
		}
		
	}
}
