using System.Net;
using AutoMapper;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Models.Models.Weather.OpenWeatherMap;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Infrastructure.Interfaces;
using WeatherAggregator.Repository.WeatherRepositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.WeatherRepositories
{
	public class OpenWeatherMapWeatherRepository : RepositoryBase<OpenWeatherMapWeatherModel>, IRepository<OpenWeatherMapWeatherModel>, IWeatherRepository
	{
		public OpenWeatherMapWeatherRepository() { }

		public OpenWeatherMapWeatherRepository(IHttpRequestor requestor) : base(requestor) { }

		public WeatherConventionModel GetWeatherData(CityModel cityModel)
		{
			var response = base.GetResponseFromUrl(this.BuildGetRequestUrl(cityModel));
			return response.StatusCode == HttpStatusCode.OK
				? Mapper.Map<OpenWeatherMapWeatherModel, WeatherConventionModel>(response.Data)
				: default(WeatherConventionModel);
		}

		private string BuildGetRequestUrl(CityModel model)
		{
			return string.IsNullOrEmpty(model.StateName) ?
				string.Format(ApisUrlsNames.OpenWeatherMapCountryURL, model.CountryName, model.CityName) :
				string.Format(ApisUrlsNames.OpenWeatherMapCountryStateURL, model.CountryName, model.StateName, model.CityName);
		}
	}
}
