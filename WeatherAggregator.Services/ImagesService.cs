using System.Globalization;
using System.Linq;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class ImagesService : IImagesService
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ImagesService).Name);


        private readonly IImagesRepository imageRepository;

		public ImagesService() { }

		public ImagesService(IImagesRepository imageRepository)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "Ctrl has been called");
			this.imageRepository = imageRepository;
		}

		public ImageModel GetImage(string imagesSearchQuery, int size)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "GetImage");

            ImagesCollectionModel images = this.imageRepository.GetImagesFromUrl(imagesSearchQuery);
			ImageModel image = this.CheckImageResponseConditions(images, size);
			image.ImageUrl = image.ImageUrl.Replace("_640", "_" + size);
			return image;
		}

		private ImageModel ReturnDefaultImage(int size)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "ReturnDefaultImage");

            return new ImageModel
			{
				ImageUrl = string.Format(ApisUrlsNames.DefaultImageSource, size)
			};
		}

		private ImageModel CheckImageResponseConditions(ImagesCollectionModel imagesCollection, int size)
		{
            log.InfoFormat(CultureInfo.InvariantCulture, "CheckImageResponseConditions");

            size = size <= 0 ? 640 : size;

			if (imagesCollection == null)
			{
				return this.ReturnDefaultImage(size);
			}

			ImageModel image = imagesCollection.Images.FirstOrDefault();
			if (image == null)
			{
				return this.ReturnDefaultImage(size);
			}

			return string.IsNullOrEmpty(image.ImageUrl) ? this.ReturnDefaultImage(size) : image;
		}
	}
}
