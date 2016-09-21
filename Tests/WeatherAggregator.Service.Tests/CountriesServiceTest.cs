using System.Collections.Generic;
using System.Linq;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services;

namespace WeatherAggregator.Service.Tests
{
	[TestClass]
	public class CountriesServiceTest
	{
		private readonly CountriesCollectionModel response = new CountriesCollectionModel
		{
			Countries = new List<CountryModel>
			{
				new CountryModel
				{
					CountryName = "CountryName",
					CountryCode = "1"
				}
			}
		};

		private Mock<ICountriesRepository> countriesRepositoryMock;

		private CountriesService countriesService;

		private Mock<ILog> logMock;

		[TestInitialize]
		public void Initialize()
		{
			this.countriesRepositoryMock = new Mock<ICountriesRepository>();
			this.logMock = new Mock<ILog>();
			this.countriesService = new CountriesService(this.countriesRepositoryMock.Object, this.logMock.Object);
		}


		[TestMethod, TestCategory("Services")]
		public void GetCountriesCollection_ShouldReturn_CountriesCollectionModel()
		{
			this.countriesRepositoryMock.Setup(x => x.GetCountriesCollection())
				.Returns(() => this.response);

			CountriesCollectionModel result = this.countriesService.GetCountriesCollection();

			Assert.AreEqual(result.Countries.First().CountryName, "CountryName");
			Assert.AreEqual(result.Countries.First().CountryCode, "1");

			this.countriesRepositoryMock.Verify(x => x.GetCountriesCollection(), Times.Once);
		}

		[TestMethod, TestCategory("Services")]
		public void GetCountriesCollection_ShouldReturn_Default()
		{
			this.countriesRepositoryMock.Setup(x => x.GetCountriesCollection())
				.Returns(() => default(CountriesCollectionModel));

			CountriesCollectionModel result = this.countriesService.GetCountriesCollection();

			Assert.IsNull(result);

			this.countriesRepositoryMock.Verify(x => x.GetCountriesCollection(), Times.Once);
		}
	}
}