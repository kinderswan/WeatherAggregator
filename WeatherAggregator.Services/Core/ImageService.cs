using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository.Repositories.Core.Interfaces;
using WeatherAggregator.Services.Core.Interfaces;

namespace WeatherAggregator.Services.Core
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService() { }

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public ImageModel GetImage(string imagesSearchQuery)
        {
            return this.imageRepository.GetImagesFromUrl(imagesSearchQuery).Images.FirstOrDefault();
        }
    }
}
