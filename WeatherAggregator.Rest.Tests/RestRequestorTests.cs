using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAggregator.Services.Models;
using WeatherAggregator.Services.Models.ThePrintfulApi;

namespace WeatherAggregator.Rest.Tests
{
	[TestClass]
	public class RestRequestorTests
	{
		[TestMethod]
		public void CheckTestMethod()
		{
			var obj = new HttpRequestor();
			var response = obj.PerformRequest<CountriesCollectionModel>(@"https://api.theprintful.com/countries",
				HttpMethod.Get);
			Debug.Write(response.Data.Countries.First(x => x.CountryName == "Australia").States[0].StateName);
		}
	}
}
