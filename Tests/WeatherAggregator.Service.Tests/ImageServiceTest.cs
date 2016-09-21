using System.Collections.Generic;
using System.Globalization;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services;

namespace WeatherAggregator.Service.Tests
{
	[TestClass]
	public class ImageServiceTest
	{
		private readonly ImagesCollectionModel response = new ImagesCollectionModel
		{
			Images = new List<ImageModel>
			{
				new ImageModel
				{
					ImageUrl = "ImageUrl"
				}
			}
		};

		private Mock<IImagesRepository> imagesRepositoryMock;

		private ImagesService imagesService;

		private Mock<ILog> logMock;

		[TestInitialize]
		public void Initialize()
		{
			this.imagesRepositoryMock = new Mock<IImagesRepository>();
			this.logMock = new Mock<ILog>();
			this.imagesService = new ImagesService(this.imagesRepositoryMock.Object, this.logMock.Object);
		}

		[TestMethod, TestCategory("Services")]
		public void GetImagesCollection_ShouldReturn_ImagesCollectionModel()
		{
			this.imagesRepositoryMock.Setup(x => x.GetImagesFromUrl(It.Is<string>(y => y == "ImageUrl")))
				.Returns(() => this.response);

			ImageModel result = this.imagesService.GetImage("ImageUrl", 640);

			Assert.AreEqual(result.ImageUrl, "ImageUrl");

			this.imagesRepositoryMock.Verify(x => x.GetImagesFromUrl(It.Is<string>(y => y == "ImageUrl")), Times.Once);
		}

		[TestMethod, TestCategory("Services")]
		public void GetImagesCollection_ShouldReturn_DefaultImagesCollectionModel()
		{
			this.imagesRepositoryMock.Setup(x => x.GetImagesFromUrl(It.Is<string>(y => y == "ImageUrl")))
				.Returns(() => null);

			ImageModel result = this.imagesService.GetImage("ImageUrl", 640);

			string baseUrl = string.Format(CultureInfo.InvariantCulture, ApisUrlsNames.DefaultImageSource, "640");

			Assert.AreEqual(result.ImageUrl, baseUrl);

			this.imagesRepositoryMock.Verify(x => x.GetImagesFromUrl(It.Is<string>(y => y == "ImageUrl")), Times.Once);
		}
	}
}