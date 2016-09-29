using System;
using System.Globalization;
using System.Net;
using log4net;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories
{
	public class ImagesRepository : RepositoryBase<ImagesCollectionModel>, IImagesRepository
	{
		private readonly ILog log;

		public ImagesRepository()
		{
		}

		public ImagesRepository(IHttpRequestor requestor, ILog log)
			: base(requestor)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
		}

		public ImagesCollectionModel GetImagesFromUrl(string imagesSearchQuery)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called with imagesSearchQuery '{0}'", imagesSearchQuery);

			if (string.IsNullOrEmpty(imagesSearchQuery))
			{
				this.log.ErrorFormat(CultureInfo.InvariantCulture, "method throwed an exception because imagesSearchQuery was null or empty");

				throw new ArgumentException(imagesSearchQuery, "imagesSearchQuery");
			}

			string url = string.Format(ApisUrlsNames.BaseImageUrl, imagesSearchQuery);
			IRestResponse<ImagesCollectionModel> response = this.GetResponseFromUrl(url);
			return response.StatusCode == HttpStatusCode.OK
				? response.Data
				: default(ImagesCollectionModel);
		}
	}
}