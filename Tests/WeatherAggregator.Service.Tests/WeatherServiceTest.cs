using System;
using System.Collections.Generic;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.WeatherRepositories.Interfaces;
using WeatherAggregator.Services;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Service.Tests
{
	[TestClass]
	public class WeatherServiceTest
	{
		private readonly WeatherConventionModel response = new WeatherConventionModel
		{
			Temperature = 20
		};

		private Mock<ILog> logMock;
		private Mock<IWeatherRepository> openWeatherMapRepositoryMock;

		private Mock<IRepositorySet> openWeatherMockSet;
		private IWeatherService weatherService;
		private Mock<IWeatherRepository> wundergroundWeatherRepositoryMock;
		private Mock<IRepositorySet> wunderWeatherMockSet;

		[TestInitialize]
		public void Initialize()
		{
			this.openWeatherMapRepositoryMock = new Mock<IWeatherRepository>();
			this.wundergroundWeatherRepositoryMock = new Mock<IWeatherRepository>();

			this.openWeatherMockSet = new Mock<IRepositorySet>();
			this.wunderWeatherMockSet = new Mock<IRepositorySet>();

			this.openWeatherMockSet.Setup(x => x.RepositorySet).Returns(RepositorySet.OpenWeatherMap);
			this.wunderWeatherMockSet.Setup(x => x.RepositorySet).Returns(RepositorySet.Wunderground);

			List<Lazy<IWeatherRepository, IRepositorySet>> di = new List<Lazy<IWeatherRepository, IRepositorySet>>
			{
				new Lazy<IWeatherRepository, IRepositorySet>(() => this.wundergroundWeatherRepositoryMock.Object,
					this.wunderWeatherMockSet.Object),
				new Lazy<IWeatherRepository, IRepositorySet>(() => this.openWeatherMapRepositoryMock.Object,
					this.openWeatherMockSet.Object)
			};

			this.logMock = new Mock<ILog>();
			this.weatherService = new WeatherService(di, this.logMock.Object);
		}

		[TestMethod]
		public void GetWeatherData_ShouldBeCalledTheOpenWeatherMap()
		{
			this.openWeatherMapRepositoryMock.Setup(x => x.GetWeatherData(It.Is<CityModel>(y => y.CityName == "CityName")))
				.Returns(this.response);

			WeatherConventionModel result = this.weatherService.GetWeatherData(new CityModel
			{
				CityName = "CityName"
			}, "openweathermap");

			Assert.AreEqual(result.Temperature, 20);
			this.openWeatherMapRepositoryMock.Verify(x => x.GetWeatherData(It.Is<CityModel>(y => y.CityName == "CityName")), Times.Once);
			this.wundergroundWeatherRepositoryMock.Verify(x => x.GetWeatherData(It.Is<CityModel>(y => y.CityName == "CityName")), Times.Never);
		}

		[TestMethod]
		public void GetWeatherData_ShouldBeCalledTheWunderweather()
		{
			this.wundergroundWeatherRepositoryMock.Setup(x => x.GetWeatherData(It.Is<CityModel>(y => y.CityName == "CityName")))
				.Returns(this.response);

			WeatherConventionModel result = this.weatherService.GetWeatherData(new CityModel
			{
				CityName = "CityName"
			}, "wunderweather");

			Assert.AreEqual(result.Temperature, 20);
			this.wundergroundWeatherRepositoryMock.Verify(x => x.GetWeatherData(It.Is<CityModel>(y => y.CityName == "CityName")), Times.Once);
			this.openWeatherMapRepositoryMock.Verify(x => x.GetWeatherData(It.Is<CityModel>(y => y.CityName == "CityName")), Times.Never);
		}
	}
}