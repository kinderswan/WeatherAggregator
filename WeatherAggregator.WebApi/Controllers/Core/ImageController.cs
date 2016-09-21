using System.Globalization;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using log4net;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Services.Interfaces;
using WeatherAggregator.WebApi.Models;

namespace WeatherAggregator.WebApi.Controllers.Core
{
	/// <summary>
	///     The image controller.
	/// </summary>
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api/images")]
	public class ImageController : ApiController
	{
		private readonly IImagesService imageService;
		private readonly ILog log;

		public ImageController()
		{
		}

		public ImageController(IImagesService imageService, ILog log)
		{
			this.log = log;
			this.imageService = imageService;

			log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
		}

		/// <summary>
		///     Endpoint for obtaining images
		/// </summary>
		/// <param name="searchQuery"></param>
		/// <param name="size">
		///     little - 180
		///     small - 340
		///     medium - 640
		///     big - 960
		/// </param>
		/// <returns></returns>
		[HttpGet]
		[Route("getimage/{searchQuery}/{size=640}")]
		public IHttpActionResult GetImage(string searchQuery, int size)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with searchQuery '{0}', size '{1}'", searchQuery, size);

			if (string.IsNullOrEmpty(searchQuery))
			{
				this.Json(default(ImageViewModel));
			}

			// ReSharper disable once AssignNullToNotNullAttribute
			string encodedSearchQuery = HttpUtility.UrlPathEncode(searchQuery);

			ImageModel result = this.imageService.GetImage(encodedSearchQuery, this.CheckRequestedSize(size));

			return this.Json(Mapper.Map<ImageModel, ImageViewModel>(result));
		}

		private int CheckRequestedSize(int size)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with size '{0}'", size);

			if (!((size == 180) || (size == 340) || (size == 640) || (size == 960)))
			{
				return 640;
			}

			return size;
		}
	}
}