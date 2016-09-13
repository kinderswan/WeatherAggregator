using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi;
using WeatherAggregator.WebApi.Controllers.Core;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.Controller.Tests
{
    [TestClass]
    public class ImagesControllerTest
    {
        private Mock<IImagesService> imagesServiceMock;

	    private Mock<ILog> logMock; 

        private ImageController imagesController;

        private readonly ImageModel response = new ImageModel
        {
            ImageUrl = "ImageUrl"
        };

        [TestInitialize]
        public void Initialize()
        {
            this.imagesServiceMock = new Mock<IImagesService>();
			this.imagesController = new ImageController(this.imagesServiceMock.Object, this.logMock.Object);
            AutoMapperConfig.Configure();
        }

        [TestMethod, TestCategory("Controllers")]
        public void GetImages_ShouldReturnImagesViewModel()
        {
            this.imagesServiceMock.Setup(x => x.GetImage("imagesSearchQuery", 640))
                .Returns(this.response).Verifiable();

            using (this.imagesController)
            {
                var result = this.imagesController.GetImage("imagesSearchQuery", 640) as JsonResult<ImageViewModel>;
                Assert.IsNotNull(result);
                Assert.AreEqual("ImageUrl", result.Content.ImageUrl);
            }
            this.imagesServiceMock.VerifyAll();
        }
    }
}
