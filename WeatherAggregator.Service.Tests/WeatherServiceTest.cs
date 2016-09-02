using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAggregator.Models.Models.Core.Cities;
using WeatherAggregator.Models.Models.Core.Countries;
using WeatherAggregator.Models.Models.Core.Images;
using WeatherAggregator.Models.Models.Core.Weather;
using WeatherAggregator.Repository;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Repository.WeatherRepositories;
using WeatherAggregator.Repository.WeatherRepositories.Interfaces;
using WeatherAggregator.Rest;
using WeatherAggregator.Services;

namespace WeatherAggregator.Service.Tests
{
	[TestClass]
	public class WeatherServiceTest
	{
		private WeatherConventionModel response = new WeatherConventionModel
		{
			Temperature = 20
		};

		[TestInitialize]
		public void Initialize()
		{

		}


	}
}
