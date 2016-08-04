using WeatherAggregator.Models.Models.Core.Images;

namespace WeatherAggregator.Services.Core.Interfaces
{
    public interface IImagesService
    {
        ImageModel GetImage(string imagesSearchQuery);
    }
}
