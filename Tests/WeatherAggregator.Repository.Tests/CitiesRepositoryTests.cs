﻿using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Repository.Repositories;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Tests
{
	[TestClass]
	public class CitiesRepositoryTests
	{
		private Mock<IHttpRequestor> httpRequestorMock;

		private CitiesRepository citiesRepository;

		private readonly CitiesContainerResponse citiesResponse = new CitiesContainerResponse
		{
			CitiesContainer = new CitiesCollectionModel
			{
				Cities = new List<CityModel>
				{
					new CityModel
					{
						StateName = "StateName",
						CountryName = "CountryName",
						CityName = "CityName"
					}
				}
			}
		};

		[TestInitialize]
		public void Initialize()
		{
			this.httpRequestorMock = new Mock<IHttpRequestor>();
			this.citiesRepository = new CitiesRepository(this.httpRequestorMock.Object);
		}

		[TestMethod]
		public void GetCitiesCollection_ShouldReturn_CitiesCollectionModel()
		{
			var url = string.Format(ApisUrlsNames.BaseCitiesUrl, "Test");

			this.httpRequestorMock.Setup(x => x.PerformRequest<CitiesContainerResponse>(It.Is<string>(y=> y == url), HttpMethod.Get).Data)
				.Returns(() => this.citiesResponse);
			this.httpRequestorMock.Setup(x => x.PerformRequest<CitiesContainerResponse>(It.Is<string>(y => y == url), HttpMethod.Get).StatusCode)
				.Returns(() => HttpStatusCode.OK);

			var result = this.citiesRepository.GetCitiesCollection("Test");
			Assert.AreEqual("StateName", result.Cities[0].StateName);
			Assert.AreEqual("CityName", result.Cities[0].CityName);
			Assert.AreEqual("CountryName", result.Cities[0].CountryName);
			this.httpRequestorMock.Verify(c => c.PerformRequest<CitiesContainerResponse>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}

		[TestMethod]
		public void GetCitiesCollection_ShouldReturn_DefaultOfCitiesCollectionModel()
		{
			var url = string.Format(ApisUrlsNames.BaseCitiesUrl, "Test");
			this.httpRequestorMock.Setup(x => x.PerformRequest<CitiesContainerResponse>(It.Is<string>(y => y == url), HttpMethod.Get).Data)
				.Returns(() => this.citiesResponse);
			var result = this.citiesRepository.GetCitiesCollection("Test");
			Assert.IsNull(result);
			this.httpRequestorMock.Verify(c => c.PerformRequest<CitiesContainerResponse>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}

		[TestMethod]
		public void GetCitiesStatesCollection_ShouldReturn_CitiesCollectionModel()
		{
			var url = string.Format(ApisUrlsNames.BaseStateCitiesUrl, "Test", "Test");

			this.httpRequestorMock.Setup(x => x.PerformRequest<CitiesContainerResponse>(It.Is<string>(y => y == url), HttpMethod.Get).Data)
				.Returns(() => this.citiesResponse);
			this.httpRequestorMock.Setup(x => x.PerformRequest<CitiesContainerResponse>(It.Is<string>(y => y == url), HttpMethod.Get).StatusCode)
				.Returns(() => HttpStatusCode.OK);

			var result = this.citiesRepository.GetCitiesCollection("Test", "Test");
			Assert.AreEqual("StateName", result.Cities[0].StateName);
			Assert.AreEqual("CityName", result.Cities[0].CityName);
			Assert.AreEqual("CountryName", result.Cities[0].CountryName);
			this.httpRequestorMock.Verify(c => c.PerformRequest<CitiesContainerResponse>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}

		[TestMethod]
		public void GetCitiesStatesCollection_ShouldReturn_DefaultOfCitiesCollectionModel()
		{
			var url = string.Format(ApisUrlsNames.BaseStateCitiesUrl, "Test", "Test");
			this.httpRequestorMock.Setup(x => x.PerformRequest<CitiesContainerResponse>(It.Is<string>(y => y == url), HttpMethod.Get).Data)
				.Returns(() => this.citiesResponse);
			var result = this.citiesRepository.GetCitiesCollection("Test", "Test");
			Assert.IsNull(result);
			this.httpRequestorMock.Verify(c => c.PerformRequest<CitiesContainerResponse>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}
	}
}
