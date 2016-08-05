using System.Linq;
using WeatherAggregator.Models.Models.Core.Images;
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
			var images = this.imageRepository.GetImagesFromUrl(imagesSearchQuery);
			var image = this.CheckImageResponseConditions(images, size);
			image.ImageUrl = image.ImageUrl.Replace("_640", "_" + size);
			return image;
		}

		private ImageModel ReturnDefaultImage(int size)
		{
			return new ImageModel
			{
				ImageUrl = @"https://lh3.ggpht.com/ApTda64T1v2cef_XzU6NHvt0nKPFTTJ1ZuBo6iuqovXTvqEGVxXxAnBH-XOz7ijNRYMONA=w" + size
			};
		}

		private ImageModel CheckImageResponseConditions(ImagesCollectionModel imagesCollection, int size)
		{
			if (imagesCollection == null)
			{
				return this.ReturnDefaultImage(size);
			}
			var image = imagesCollection.Images.FirstOrDefault();
			if (image == null)
			{
				return this.ReturnDefaultImage(size);
			}
			return string.IsNullOrEmpty(image.ImageUrl) ? this.ReturnDefaultImage(size) : image;
		}
	}
}
