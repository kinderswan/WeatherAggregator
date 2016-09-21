using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository.Infrastructure.Interfaces;

namespace WeatherAggregator.Repository.Repositories.Interfaces
{
	public interface IImagesRepository : IRepository<ImagesCollectionModel>
	{
		ImagesCollectionModel GetImagesFromUrl(string imagesSearchQuery);
	}
}