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
	/// The image controller.
	/// </summary>
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api/images")]
	public class ImageController : ApiController
	{
	    private readonly ILog log;

        private readonly IImagesService imageService;

		public ImageController() { }

		public ImageController(IImagesService imageService, ILog log)
		{
		    this.log = log;
            this.imageService = imageService;

            log.InfoFormat(CultureInfo.InvariantCulture, "Ctrl has been called");
            
		}


		/// <summary>
		/// Endpoint for obtaining images
		/// </summary>
		/// <param name="searchQuery"></param>
		/// <param name="size">
		/// little - 180
		/// small - 340
		/// medium - 640
		/// big - 960
		/// </param>
		/// <returns></returns>
		[HttpGet]
		[Route("getimage/{searchQuery}/{size=640}")]
		public IHttpActionResult GetImage(string searchQuery, int size)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "GetImage");

            if (string.IsNullOrEmpty(searchQuery))
		    {
		        Json(default(ImageViewModel));
		    }

			string encodedSearchQuery = HttpUtility.UrlPathEncode(searchQuery);

			ImageModel result = this.imageService.GetImage(encodedSearchQuery, this.CheckRequestedSize(size));

			return Json(Mapper.Map<ImageModel, ImageViewModel>(result));
		}

		private int CheckRequestedSize(int size)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "CheckRequestedSize");

            if (!(size == 180 || size == 340 || size == 640 || size == 960))
			{
				return 640;
			}

			return size;
		}
	}
}
