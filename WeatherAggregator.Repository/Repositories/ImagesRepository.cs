using System.Net;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class ImagesRepository : RepositoryBase<ImagesCollectionModel>, IImagesRepository
	{
		public ImagesRepository() { }

		public ImagesRepository(IHttpRequestor requestor) : base(requestor) { }

		public ImagesCollectionModel GetImagesFromUrl(string imagesSearchQuery)
		{
			string url = string.Format(ApisUrlsNames.BaseImageUrl, imagesSearchQuery);
			IRestResponse<ImagesCollectionModel> response = base.GetResponseFromUrl(url);
			return response.StatusCode == HttpStatusCode.OK
				? response.Data
				: default(ImagesCollectionModel);
		}
	}
}
