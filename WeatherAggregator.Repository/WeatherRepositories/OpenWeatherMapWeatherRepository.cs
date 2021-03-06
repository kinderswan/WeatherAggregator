﻿using System.Globalization;
using System.Net;
using AutoMapper;
using log4net;
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
		private readonly ILog log;

		public OpenWeatherMapWeatherRepository()
		{
		}

		public OpenWeatherMapWeatherRepository(IHttpRequestor requestor, ILog log)
			: base(requestor)
		{
			this.log = log;
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
		}

		public WeatherConventionModel GetWeatherData(CityModel cityModel)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");

			IRestResponse<OpenWeatherMapWeatherModel> response = this.GetResponseFromUrl(this.BuildGetRequestUrl(cityModel));
			return response.StatusCode == HttpStatusCode.OK
				? Mapper.Map<OpenWeatherMapWeatherModel, WeatherConventionModel>(response.Data)
				: default(WeatherConventionModel);
		}

		private string BuildGetRequestUrl(CityModel model)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");

			return string.IsNullOrEmpty(model.StateName)
				? string.Format(ApisUrlsNames.OpenWeatherMapCountryURL, model.CountryName, model.CityName)
				: string.Format(ApisUrlsNames.OpenWeatherMapCountryStateURL, model.CountryName, model.StateName, model.CityName);
		}
	}
}