using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Weather.Wunderground;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.WeatherRepositories.Interfaces;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Repository.Repositories.WeatherRepositories
{
	public class WundergroundWeatherRepository : RepositoryBase<WeatherModel>, IWundergroundWeatherRepository
	{
		private const string WeatherCountryStateURL = @"http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}/{1}/{2}.json";
		
		private const string WeatherCountryURL = @"http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}/{1}.json";

		public WundergroundWeatherRepository() { }

		public WundergroundWeatherRepository(IHttpRequestor httpRequestor) : base(httpRequestor) { }

		public WeatherModel GetWeatherData(CityModel cityModel)
		{
			return base.GetResponseFromUrl(this.BuildGetRequestUrl(cityModel));
		}

        private string BuildGetRequestUrl(CityModel model)
		{
			return string.IsNullOrEmpty(model.StateName) ?
				string.Format(WeatherCountryURL, model.CountryName, model.CityName) :
				string.Format(WeatherCountryStateURL, model.CountryName, model.StateName, model.CityName);
		}
	}
}
