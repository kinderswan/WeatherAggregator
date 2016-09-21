using System;
using System.Collections.Generic;
using System.Net;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository.Repositories;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Tests
{
	[TestClass]
	public class ImagesRepositoryTests
	{
		private Mock<IHttpRequestor> httpRequestorMock;

	    private Mock<ILog> logMock;

		private ImagesRepository imagesRepository;

		private readonly ImagesCollectionModel imagesResponse = new ImagesCollectionModel
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
			this.httpRequestorMock = new Mock<IHttpRequestor>();
            this.logMock = new Mock<ILog>();
			this.imagesRepository = new ImagesRepository(this.httpRequestorMock.Object, this.logMock.Object);
		}

		[TestMethod, TestCategory("Repositories")]
		public void GetImagesFromUrl_ShouldReturn_ImagesCollectionModel()
		{
			string url = string.Format(ApisUrlsNames.BaseImageUrl, "Test");

			this.httpRequestorMock.Setup(x => x.PerformRequest<ImagesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get).Data)
				.Returns(() => this.imagesResponse);

			this.httpRequestorMock.Setup(x => x.PerformRequest<ImagesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get).StatusCode)
				.Returns(() => HttpStatusCode.OK);

			ImagesCollectionModel result = this.imagesRepository.GetImagesFromUrl("Test");
			Assert.AreEqual("ImageUrl", result.Images[0].ImageUrl);
			this.httpRequestorMock.Verify(c => c.PerformRequest<ImagesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}

		[TestMethod, TestCategory("Repositories")]
		public void GetImagesFromUrl_ShouldReturn_DefaultOfImagesCollectionModel()
		{
			string url = string.Format(ApisUrlsNames.BaseImageUrl, "Test");

			this.httpRequestorMock.Setup(x => x.PerformRequest<ImagesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get).Data)
				.Returns(() => this.imagesResponse);

			ImagesCollectionModel result = this.imagesRepository.GetImagesFromUrl("Test");
			Assert.IsNull(result);
			this.httpRequestorMock.Verify(c => c.PerformRequest<ImagesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}

		[TestMethod, TestCategory("Repositories")]
		public void GetImagesFromUrl_ShouldReturn_DefaultOfImagesCollectionModel_IfResponseDataIsNull()
		{
			string url = string.Format(ApisUrlsNames.BaseImageUrl, "Test");

			this.httpRequestorMock.Setup(x => x.PerformRequest<ImagesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get).Data)
				.Returns(() => default(ImagesCollectionModel));
			this.httpRequestorMock.Setup(x => x.PerformRequest<ImagesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get).StatusCode)
				.Returns(() => HttpStatusCode.OK);

			ImagesCollectionModel result = this.imagesRepository.GetImagesFromUrl("Test");
			Assert.IsNull(result);
			this.httpRequestorMock.Verify(c => c.PerformRequest<ImagesCollectionModel>(It.Is<string>(y => y == url), HttpMethod.Get), Times.Once());
		}

        [TestMethod, TestCategory("Repositories")]
        [ExpectedException(typeof(ArgumentException))]
        public void GetImagesFromUrl_StringEmpty_ArgumentException()
        {
            this.imagesRepository.GetImagesFromUrl(string.Empty);
        }

        [TestMethod, TestCategory("Repositories")]
        [ExpectedException(typeof(ArgumentException))]
        public void GetImagesFromUrl_StringNull_ArgumentException()
        {
            this.imagesRepository.GetImagesFromUrl(null);
        }
    }
}
