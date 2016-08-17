using System.Linq;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.Services
{
	public class ImagesService : IImagesService
	{
		private readonly IImagesRepository imageRepository;

		public ImagesService() { }

		public ImagesService(IImagesRepository imageRepository)
		{
			this.imageRepository = imageRepository;
		}

		public ImageModel GetImage(string imagesSearchQuery, int size)
		{
			ImagesCollectionModel images = this.imageRepository.GetImagesFromUrl(imagesSearchQuery);
			ImageModel image = this.CheckImageResponseConditions(images, size);
			image.ImageUrl = image.ImageUrl.Replace("_640", "_" + size);
			return image;
		}

		private ImageModel ReturnDefaultImage(int size)
		{
			return new ImageModel
			{
				ImageUrl = string.Format(ApisUrlsNames.DefaultImageSource, size)
			};
		}

		private ImageModel CheckImageResponseConditions(ImagesCollectionModel imagesCollection, int size)
		{
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
