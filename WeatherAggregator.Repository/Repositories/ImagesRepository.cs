using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class ImagesRepository : RepositoryBase<ImagesCollectionModel>, IImagesRepository
	{
		private const string BaseImageUrl = @"https://pixabay.com/api/?key=3018114-ef10ea70a2ba5da78d32b52be&q={0}&image_type=photo";

		public ImagesRepository() { }

		public ImagesRepository(IHttpRequestor requestor) : base(requestor) { }

		public ImagesCollectionModel GetImagesFromUrl(string imagesSearchQuery)
		{
			string url = string.Format(ImagesRepository.BaseImageUrl, imagesSearchQuery);
			return base.GetResponseFromUrl(url);
		}
	}
}
