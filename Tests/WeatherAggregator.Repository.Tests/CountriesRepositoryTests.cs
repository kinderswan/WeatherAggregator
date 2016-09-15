using System.Collections.Generic;
using System.Net;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Repositories;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Tests
{
	[TestClass]
	public class CountriesRepositoryTests
	{
		private Mock<IHttpRequestor> httpRequestorMock;

	    private Mock<ILog> logMock;

		private CountriesRepository countriesRepository;

		private readonly CountriesCollectionModel countriesResponse = new CountriesCollectionModel
		{
			Countries = new List<CountryModel>
			{
				new CountryModel
				{
					CountryName = "CountryName",
					CountryCode = "CountryCode",
					States = null
				}
			}
		};

		[TestInitialize]
		public void Initialize()
		{
			this.httpRequestorMock = new Mock<IHttpRequestor>();
            this.logMock = new Mock<ILog>();
			this.countriesRepository = new CountriesRepository(this.httpRequestorMock.Object, this.logMock.Object);
		}

		[TestMethod, TestCategory("Repositories")]
		public void GetCountriesCollection_ShouldReturn_CountriesCollectionModel()
		{
			string url = string.Format(ApisUrlsNames.BaseCountriesUrl);

			this.httpRequestorMock.Setup(x => x.PerformRequest<CountriesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get).Data)
				.Returns(() => this.countriesResponse);

			this.httpRequestorMock.Setup(x => x.PerformRequest<CountriesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get).StatusCode)
				.Returns(() => HttpStatusCode.OK);

			CountriesCollectionModel result = this.countriesRepository.GetCountriesCollection();
			Assert.AreEqual("CountryCode", result.Countries[0].CountryCode);
			Assert.AreEqual("CountryName", result.Countries[0].CountryName);
			Assert.AreEqual(null, result.Countries[0].States);
			this.httpRequestorMock.Verify(c => c.PerformRequest<CountriesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}

		[TestMethod, TestCategory("Repositories")]
		public void GetCountriesCollection_ShouldReturn_DefaultOfCountriesCollectionModel_IfResponseDataIsNull()
		{
			string url = string.Format(ApisUrlsNames.BaseCountriesUrl);

			this.httpRequestorMock.Setup(x => x.PerformRequest<CountriesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get).Data)
				.Returns(() => default(CountriesCollectionModel));

			this.httpRequestorMock.Setup(x => x.PerformRequest<CountriesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get).StatusCode)
				.Returns(() => HttpStatusCode.OK);

			CountriesCollectionModel result = this.countriesRepository.GetCountriesCollection();
			Assert.IsNull(result);
			this.httpRequestorMock.Verify(c => c.PerformRequest<CountriesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}
	}
}
