using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services;

namespace WeatherAggregator.Service.Tests
{
	[TestClass]
	public class ImageServiceTest
	{
		private Mock<IImagesRepository> imagesRepositoryMock;

		private ImagesService imagesService;

		private ImagesCollectionModel response = new ImagesCollectionModel
		{
			Images = new List<ImageModel>
			{
				new ImageModel
				{
					ImageUrl = "ImageUrl"
				}
			}
		};

		[TestInitialize]
		public void Initialize()
		{
			this.imagesRepositoryMock = new Mock<IImagesRepository>();
			this.imagesService = new ImagesService(this.imagesRepositoryMock.Object);
		}


		[TestMethod, TestCategory("Services")]
		public void GetImagesCollection_ShouldReturn_ImagesCollectionModel()
		{
			this.imagesRepositoryMock.Setup(x => x.GetImagesFromUrl(It.Is<string>(y => y == "ImageUrl")))
				.Returns(() => this.response);

			var result = this.imagesService.GetImage("ImageUrl", 640);

			Assert.AreEqual(result.ImageUrl, "ImageUrl");

			this.imagesRepositoryMock.Verify(x => x.GetImagesFromUrl(It.Is<string>(y => y == "ImageUrl")), Times.Once);
		}

		[TestMethod, TestCategory("Services")]
		public void GetImagesCollection_ShouldReturn_DefaultImagesCollectionModel()
		{
			this.imagesRepositoryMock.Setup(x => x.GetImagesFromUrl(It.Is<string>(y => y == "ImageUrl")))
				.Returns(() => null);

			var result = this.imagesService.GetImage("ImageUrl", 640);

			string baseUrl = string.Format(CultureInfo.InvariantCulture, ApisUrlsNames.DefaultImageSource, "640");

			Assert.AreEqual(result.ImageUrl, baseUrl);

			this.imagesRepositoryMock.Verify(x => x.GetImagesFromUrl(It.Is<string>(y => y == "ImageUrl")), Times.Once);
		}
	}
}
