using WeatherAggregator.Models.Models.Core.Images;

namespace WeatherAggregator.Services.Interfaces
{
	public interface IImagesService
	{
		ImageModel GetImage(string imagesSearchQuery, int size);
	}
}