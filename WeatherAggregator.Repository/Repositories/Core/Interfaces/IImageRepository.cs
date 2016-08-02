using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository.Infrastructure.Interfaces;

namespace WeatherAggregator.Repository.Repositories.Core.Interfaces
{
    public interface IImageRepository : IRepository<ImagesCollectionModel>
    {
        ImagesCollectionModel GetImagesFromUrl(string imagesSearchQuery);
    }
}
