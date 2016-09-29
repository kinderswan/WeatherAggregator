using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi;
using WeatherAggregator.WebApi.Controllers.Core;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.Controller.Tests
{
	[TestClass]
	public class CountriesControllerTest
	{
		private readonly CountriesCollectionModel response = new CountriesCollectionModel
		{
			Countries = new List<CountryModel>
			{
				new CountryModel
				{
					CountryName = "CountryName"
				}
			}
		};

		private CountriesController CountriesController;
		private Mock<ICountriesService> CountriesServiceMock;

		private Mock<ILog> logMock;

		[TestInitialize]
		public void Initialize()
		{
			this.CountriesServiceMock = new Mock<ICountriesService>();
			this.logMock = new Mock<ILog>();
			this.CountriesController = new CountriesController(this.CountriesServiceMock.Object, this.logMock.Object);
			AutoMapperConfig.Configure();
		}

		[TestMethod, TestCategory("Controllers")]
		public void GetCountries_ShouldReturnCountriesViewModel()
		{
			this.CountriesServiceMock.Setup(x => x.GetCountriesCollection())
				.Returns(this.response).Verifiable();

			using (this.CountriesController)
			{
				JsonResult<List<CountryViewModel>> result = this.CountriesController.GetCountries() as JsonResult<List<CountryViewModel>>;
				Assert.IsNotNull(result);
				Assert.AreEqual("CountryName", result.Content.FirstOrDefault().CountryName);
			}

			this.CountriesServiceMock.VerifyAll();
		}
	}
}