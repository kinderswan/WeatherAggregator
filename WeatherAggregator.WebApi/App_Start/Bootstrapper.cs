using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using WeatherAggregator.Repository.Repositories.WeatherRepositories.Interfaces;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;
using WeatherAggregator.Services.WeatherServices.Interfaces;

namespace WeatherAggregator.WebApi.App_Start
{
	public class Bootstrapper
	{
		public static void Run()
		{
			Bootstrapper.SetAutofacContainer();
		}

		private static void SetAutofacContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();

			builder.RegisterType<HttpRequestor>().As<IHttpRequestor>().InstancePerRequest();

			builder.RegisterGeneric(typeof(RestResponse<>)).As(typeof(IRestResponse<>)).InstancePerRequest();

			builder.RegisterAssemblyTypes(typeof(IWundergroundWeatherRepository).Assembly)
				.Where(t => t.Name.EndsWith("Repository"))
				.AsImplementedInterfaces().InstancePerRequest();
			builder.RegisterAssemblyTypes(typeof(IWundergroundWeatherService).Assembly)
				.AsImplementedInterfaces().InstancePerRequest();

			

			IContainer container = builder.Build();
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}