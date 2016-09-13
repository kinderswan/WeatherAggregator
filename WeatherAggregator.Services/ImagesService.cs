using System.Globalization;
using System.Linq;
using log4net;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class ImagesService : IImagesService
	{
		private readonly log4net.ILog log;


		private readonly IImagesRepository imageRepository;

		public ImagesService() { }

		public ImagesService(IImagesRepository imageRepository, ILog log)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.imageRepository = imageRepository;
		}

		public ImageModel GetImage(string imagesSearchQuery, int size)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with imagesSearchQuery '{0}', size '{1}'", imagesSearchQuery, size);

			ImagesCollectionModel images = this.imageRepository.GetImagesFromUrl(imagesSearchQuery);
			ImageModel image = this.CheckImageResponseConditions(images, size);
			image.ImageUrl = image.ImageUrl.Replace("_640", "_" + size);
			return image;
		}

		private ImageModel ReturnDefaultImage(int size)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with size '{0}'",  size);

			return new ImageModel
			{
				ImageUrl = string.Format(ApisUrlsNames.DefaultImageSource, size)
			};
		}

		private ImageModel CheckImageResponseConditions(ImagesCollectionModel imagesCollection, int size)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with size '{0}'", size);

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
