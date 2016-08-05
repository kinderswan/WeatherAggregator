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
			var image = this.imageRepository.GetImagesFromUrl(imagesSearchQuery).Images.FirstOrDefault();

			if (image == null)
			{
				//todo: return blank or default image if it is possible
				return null;
			}

			image.ImageUrl = image.ImageUrl.Replace("_640", "_" + size);
			return image;
		}
	}
}
