using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services;

namespace WeatherAggregator.Service.Tests
{
	[TestClass]
	public class CountriesServiceTest
	{
		private Mock<ICountriesRepository> countriesRepositoryMock;

	    private Mock<ILog> logMock;

		private CountriesService countriesService;

		private readonly CountriesCollectionModel response = new CountriesCollectionModel()
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

			var result = this.countriesService.GetCountriesCollection();

			Assert.AreEqual(result.Countries.First().CountryName, "CountryName");
			Assert.AreEqual(result.Countries.First().CountryCode, "1");

			this.countriesRepositoryMock.Verify(x => x.GetCountriesCollection(), Times.Once);
		}

        [TestMethod, TestCategory("Services")]
        public void GetCountriesCollection_ShouldReturn_Default()
        {
            this.countriesRepositoryMock.Setup(x => x.GetCountriesCollection())
                .Returns(() => default(CountriesCollectionModel));

            var result = this.countriesService.GetCountriesCollection();

            Assert.IsNull(result);

            this.countriesRepositoryMock.Verify(x => x.GetCountriesCollection(), Times.Once);
        }
    }
}
