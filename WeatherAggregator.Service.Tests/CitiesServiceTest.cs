using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services;

namespace WeatherAggregator.Service.Tests
{
	[TestClass]
	public class CitiesServiceTest
	{
		private Mock<ICitiesRepository> citiesRepositoryMock;

		private CitiesService citiesService;

		private CitiesCollectionModel response = new CitiesCollectionModel
		{
			Cities = new List<CityModel>
			{
				new CityModel()
				{
					CountryName = "CountryName",
					CityName = "CityName",
					StateName = "StateName"
				}
			}
		};

		[TestInitialize]
		public void Initialize()
		{
			this.citiesRepositoryMock = new Mock<ICitiesRepository>();
			this.citiesService = new CitiesService(this.citiesRepositoryMock.Object);
		}


		[TestMethod, TestCategory("Services")]
		public void GetCitiesCollection_ShouldReturn_CitiesCollectionModel()
		{
			this.citiesRepositoryMock.Setup(x => x.GetCitiesCollection(It.Is<string>(y => y == "CountryName")))
				.Returns(() => this.response);

			var result = this.citiesService.GetCitiesCollection("CountryName");

			Assert.AreEqual(result.Cities.First().CountryName, "CountryName");
			Assert.AreEqual(result.Cities.First().CityName, "CityName");
			Assert.AreEqual(result.Cities.First().StateName, "StateName");


			this.citiesRepositoryMock.Verify(x => x.GetCitiesCollection(It.Is<string>(y => y == "CountryName")), Times.Once);
		}

		[TestMethod, TestCategory("Services")]
		public void GetCitiesStateCollection_ShouldReturn_CitiesCollectionModel()
		{
			this.citiesRepositoryMock.Setup(
				x => x.GetCitiesCollection(It.Is<string>(y => y == "CountryName"), It.Is<string>(z => z == "StateName")))
				.Returns(() => this.response);

			var result = this.citiesService.GetCitiesCollection("CountryName", "StateName");

			Assert.AreEqual(result.Cities.First().CountryName, "CountryName");
			Assert.AreEqual(result.Cities.First().CityName, "CityName");
			Assert.AreEqual(result.Cities.First().StateName, "StateName");


			this.citiesRepositoryMock.Verify(x => x.GetCitiesCollection(It.Is<string>(y => y == "CountryName"), It.Is<string>(z => z == "StateName")), Times.Once);
		}
	}
}
