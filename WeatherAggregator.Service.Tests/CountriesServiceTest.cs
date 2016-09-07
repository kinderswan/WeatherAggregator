﻿using System;
using System.Collections.Generic;
using System.Linq;
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

		private CountriesService countriesService;

		private CountriesCollectionModel response = new CountriesCollectionModel()
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
			this.countriesService = new CountriesService(this.countriesRepositoryMock.Object);
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
	}
}