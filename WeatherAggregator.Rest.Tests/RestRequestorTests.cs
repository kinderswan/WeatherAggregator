using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAggregator.Rest.Tests.Models;

namespace WeatherAggregator.Rest.Tests
{
	[TestClass]
	public class RestRequestorTests
	{
		[TestMethod]
		public void CheckTestMethod()
		{
			var obj = new HttpRequestor();
			var response = obj.PerformRequest<WeatherModel>(@"http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/BY/Brest.json",
				HttpMethod.Get);
			Debug.Write(response.Data.CurrentObservation.IconUrl);
		}
	}
}
