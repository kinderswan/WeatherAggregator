using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mef;
using Autofac.Integration.WebApi;
using WeatherAggregator.Repository.Infrastructure;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Repository.WeatherRepositories;
using WeatherAggregator.Repository.WeatherRepositories.Interfaces;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;
using WeatherAggregator.Services;
using WeatherAggregator.Services.Interfaces;

namespace WeatherAggregator.WebApi
{
	public class Bootstrapper
	{
		public static void Run()
		{
			Bootstrapper.SetAutofacContainer();
			AutoMapperConfig.Configure();
		}

		private static void SetAutofacContainer()
		{
			var builder = new ContainerBuilder();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
			builder.RegisterMetadataRegistrationSources();

			builder.Register(c => new HttpRequestor(new HttpClient())).As<IHttpRequestor>().SingleInstance();

			builder.RegisterGeneric(typeof(RestResponse<>)).As(typeof(IRestResponse<>)).InstancePerRequest();

			builder.RegisterAssemblyTypes(typeof(IImagesRepository).Assembly)
				.Where(t => t.Name.EndsWith("Repository") && !t.Name.Contains("Weather"))
				.AsImplementedInterfaces().InstancePerRequest();

			builder.RegisterAssemblyTypes(typeof(ICitiesService).Assembly)
				.Where(t => t.Name.EndsWith("Service") && !t.Name.Contains("Weather"))
				.AsImplementedInterfaces().InstancePerRequest();

			#region Weather containers resolving

			builder.Register(c => new WundergroundWeatherRepository(
				c.Resolve<IHttpRequestor>()))
				.As<IWeatherRepository>()
				.WithMetadata<IRepositorySet>(m =>
					m.For(em => em.RepositorySet, RepositorySet.Wunderground));

			builder.Register(c => new OpenWeatherMapWeatherRepository(
				c.Resolve<IHttpRequestor>()))
				.As<IWeatherRepository>()
				.WithMetadata<IRepositorySet>(m =>
					m.For(em => em.RepositorySet, RepositorySet.OpenWeatherMap));

			builder.Register(c => new WeatherService(
				c.Resolve<IEnumerable<Lazy<IWeatherRepository, IRepositorySet>>>()))
				.As<IWeatherService>().InstancePerRequest();

			#endregion

			IContainer container = builder.Build();
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}

	}
}