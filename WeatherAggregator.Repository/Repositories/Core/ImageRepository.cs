using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Core.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories.Core
{
    public class ImageRepository : RepositoryBase<ImagesCollectionModel>, IImageRepository
    {
        private const string BaseImageUrl = @"https://pixabay.com/api/?key=3018114-ef10ea70a2ba5da78d32b52be&q={0}&image_type=photo";

        public ImageRepository() { }

        public ImageRepository(IHttpRequestor requestor) : base(requestor) { }

        public ImagesCollectionModel GetImagesFromUrl(string imagesSearchQuery)
        {
            string url = string.Format(ImageRepository.BaseImageUrl, imagesSearchQuery);
            return base.GetResponseFromUrl(url);
        }
    }
}
