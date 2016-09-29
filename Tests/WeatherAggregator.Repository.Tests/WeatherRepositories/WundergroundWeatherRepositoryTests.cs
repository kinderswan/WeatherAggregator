using System.Net;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.Repository.WeatherRepositories;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;
using WeatherAggregator.WebApi;

namespace WeatherAggregator.Repository.Tests.WeatherRepositories
{
	[TestClass]
	public class WundergroundWeatherRepositoryTests
	{
		private readonly WundergroundWeatherModel weatherResponse = new WundergroundWeatherModel
		{
			CurrentObservation = new WundergroundCurrentObservation
			{
				TemperatureCelsius = 20
			}
		};

		private Mock<IHttpRequestor> httpRequestorMock;

		private Mock<ILog> logMock;

		private WundergroundWeatherRepository weatherRepository;

		[TestInitialize]
		public void Initialize()
		{
			this.httpRequestorMock = new Mock<IHttpRequestor>();
			this.logMock = new Mock<ILog>();
			this.weatherRepository = new WundergroundWeatherRepository(this.httpRequestorMock.Object, this.logMock.Object);
			AutoMapperConfig.Configure();
		}

		[TestMethod, TestCategory("Repositories")]
		public void GetWeatherData_ShouldReturn_WeatherConventionModel()
		{
			string url = string.Format(ApisUrlsNames.WundergroundCountryURL, "CountryName", "CityName");

			this.httpRequestorMock.Setup(x => x.PerformRequest<WundergroundWeatherModel>(It.Is<string>(y => y == url), HttpMethod.Get).Data)
				.Returns(() => this.weatherResponse);
			this.httpRequestorMock.Setup(x => x.PerformRequest<WundergroundWeatherModel>(It.Is<string>(y => y == url), HttpMethod.Get).StatusCode)
				.Returns(() => HttpStatusCode.OK);

			WeatherConventionModel result = this.weatherRepository.GetWeatherData(new CityModel
			{
				CityName = "CityName",
				CountryName = "CountryName"
			});

			Assert.AreEqual(20, result.Temperature);
			this.httpRequestorMock.Verify(c => c.PerformRequest<WundergroundWeatherModel>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}

		[TestMethod, TestCategory("Repositories")]
		public void GetWeatherDataState_ShouldReturn_WeatherConventionModel()
		{
			string url = string.Format(ApisUrlsNames.WundergroundCountryStateURL, "CountryName", "StateName", "CityName");

			this.httpRequestorMock.Setup(x => x.PerformRequest<WundergroundWeatherModel>(It.Is<string>(y => y == url), HttpMethod.Get).Data)
				.Returns(() => this.weatherResponse);
			this.httpRequestorMock.Setup(x => x.PerformRequest<WundergroundWeatherModel>(It.Is<string>(y => y == url), HttpMethod.Get).StatusCode)
				.Returns(() => HttpStatusCode.OK);

			WeatherConventionModel result = this.weatherRepository.GetWeatherData(new CityModel
			{
				CityName = "CityName",
				CountryName = "CountryName",
				StateName = "StateName"
			});

			Assert.AreEqual(20, result.Temperature);
			this.httpRequestorMock.Verify(c => c.PerformRequest<WundergroundWeatherModel>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}
	}
}