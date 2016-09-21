using System.Globalization;
using System.Net;
using AutoMapper;
using log4net;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Infrastructure.Interfaces;
using WeatherAggregator.Repository.WeatherRepositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.WeatherRepositories
{
	public class WundergroundWeatherRepository : RepositoryBase<WundergroundWeatherModel>, IRepository<WundergroundWeatherModel>, IWeatherRepository
	{
	    private readonly log4net.ILog log;
		public WundergroundWeatherRepository() { }

		public WundergroundWeatherRepository(IHttpRequestor requestor, ILog log)
			: base(requestor)
		{
		    this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
		}

		public WeatherConventionModel GetWeatherData(CityModel cityModel)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");
			IRestResponse<WundergroundWeatherModel> response = base.GetResponseFromUrl(this.BuildGetRequestUrl(cityModel));
			return response.StatusCode == HttpStatusCode.OK
				? Mapper.Map<WundergroundWeatherModel, WeatherConventionModel>(response.Data)
				: default(WeatherConventionModel);
		}

		private string BuildGetRequestUrl(CityModel model)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");
			return string.IsNullOrEmpty(model.StateName) ?
				string.Format(ApisUrlsNames.WundergroundCountryURL, model.CountryName, model.CityName) :
				string.Format(ApisUrlsNames.WundergroundCountryStateURL, model.CountryName, model.StateName, model.CityName);
		}
	}
}
