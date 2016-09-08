using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Repository;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Repository.WeatherRepositories;
using WeatherAggregator.Repository.WeatherRepositories.Interfaces;
using WeatherAggregator.Rest;
using WeatherAggregator.Services;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Service.Tests
{
	[TestClass]
	public class WeatherServiceTest
	{
		private IWeatherService weatherService;
		private Mock<IWeatherRepository> wundergroundWeatherRepositoryMock;
		private Mock<IWeatherRepository> openWeatherMapRepositoryMock;

		private Mock<IRepositorySet> openWeatherMockSet; 
		private Mock<IRepositorySet> wunderWeatherMockSet; 

		private WeatherConventionModel response = new WeatherConventionModel
		{
			Temperature = 20
		};

		[TestInitialize]
		public void Initialize()
		{
			this.openWeatherMapRepositoryMock = new Mock<IWeatherRepository>();
			this.wundergroundWeatherRepositoryMock = new Mock<IWeatherRepository>();

			this.openWeatherMockSet = new Mock<IRepositorySet>();
			this.wunderWeatherMockSet = new Mock<IRepositorySet>();

			this.openWeatherMockSet.Setup(x => x.RepositorySet).Returns(RepositorySet.OpenWeatherMap);
			this.wunderWeatherMockSet.Setup(x => x.RepositorySet).Returns(RepositorySet.Wunderground);

			var di = new List<Lazy<IWeatherRepository, IRepositorySet>>
			{
				new Lazy<IWeatherRepository, IRepositorySet>(() => this.wundergroundWeatherRepositoryMock.Object,
					this.wunderWeatherMockSet.Object),
				new Lazy<IWeatherRepository, IRepositorySet>(() => this.openWeatherMapRepositoryMock.Object,
					this.openWeatherMockSet.Object)
			};

			this.weatherService = new WeatherService(di);
		}

		[TestMethod]
		public void GetWeatherData_ShouldBeCalledTheProperRepository()
		{
			this.openWeatherMapRepositoryMock.Setup(x => x.GetWeatherData(It.Is<CityModel>(y => y.CityName == "CityName")))
				.Returns(this.response);

			var result = this.weatherService.GetWeatherData(new CityModel
			{
				CityName = "CityName"
			}, "openweathermap");

			Assert.AreEqual(result.Temperature, 20);
			this.openWeatherMapRepositoryMock.Verify(x => x.GetWeatherData(It.Is<CityModel>(y => y.CityName == "CityName")), Times.Once);
			this.wundergroundWeatherRepositoryMock.Verify(x => x.GetWeatherData(It.Is<CityModel>(y => y.CityName == "CityName")), Times.Never);
		}
	}
}
