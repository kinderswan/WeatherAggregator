using System;
using System.Globalization;
using System.Net;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class ImagesRepository : RepositoryBase<ImagesCollectionModel>, IImagesRepository
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ImagesRepository).Name);

		public ImagesRepository() { }

		public ImagesRepository(IHttpRequestor requestor)
			: base(requestor)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
		}

		public ImagesCollectionModel GetImagesFromUrl(string imagesSearchQuery)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with imagesSearchQuery '{0}'", imagesSearchQuery);

			if (string.IsNullOrEmpty(imagesSearchQuery))
			{
				log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because imagesSearchQuery was null or empty");

				throw new ArgumentException(imagesSearchQuery, "imagesSearchQuery");
			}

			string url = string.Format(ApisUrlsNames.BaseImageUrl, imagesSearchQuery);
			IRestResponse<ImagesCollectionModel> response = base.GetResponseFromUrl(url);
			return response.StatusCode == HttpStatusCode.OK
				? response.Data
				: default(ImagesCollectionModel);
		}
	}
}
