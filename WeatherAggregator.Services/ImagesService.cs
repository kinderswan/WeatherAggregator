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

        public ImageModel GetImage(string imagesSearchQuery)
        {
            return this.imageRepository.GetImagesFromUrl(imagesSearchQuery).Images.FirstOrDefault();
        }
    }
}
