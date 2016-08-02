using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Services.Core.Interfaces;

namespace WeatherAggregator.WebApi.Controllers.Core
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        private readonly IImageService imageService;

        public ImageController() { }

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet]
        [Route("getimage/{searchQuery}")]
        public IHttpActionResult GetImage(string searchQuery)
        {
            string encodedSearchQuery = HttpUtility.UrlPathEncode(searchQuery);

            ImageModel result = this.imageService.GetImage(encodedSearchQuery);

            return Json(result);
        }

    }
}
