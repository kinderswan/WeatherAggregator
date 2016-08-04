﻿using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Services.Core.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.Core
{
	[EnableCors(origins: "http://localhost:666", headers: "*", methods: "*")]
	[RoutePrefix("api/images")]
	public class ImageController : ApiController
	{
		private readonly IImagesService imageService;

		public ImageController() { }

		public ImageController(IImagesService imageService)
		{
			this.imageService = imageService;
		}

		[HttpGet]
		[Route("getimage/{searchQuery}")]
		public IHttpActionResult GetImage(string searchQuery)
		{
			string encodedSearchQuery = HttpUtility.UrlPathEncode(searchQuery);

			ImageModel result = this.imageService.GetImage(encodedSearchQuery);

			return Json(Mapper.Map<ImageModel, ImageViewModel>(result));
		}

	}
}
