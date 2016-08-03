using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WeatherAggregator.Repository.Repositories;
using WeatherAggregator.Repository.Repositories.Interfaces;
using WeatherAggregator.Rest;
using WeatherAggregator.Rest.Interfaces;
using WeatherAggregator.Services.WeatherServices.Interfaces;

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

			builder.RegisterType<HttpRequestor>().As<IHttpRequestor>().SingleInstance();

			builder.RegisterGeneric(typeof(RestResponse<>)).As(typeof(IRestResponse<>)).InstancePerRequest();

			builder.RegisterGeneric(typeof(WeatherRepository<>)).As(typeof(IWeatherRepository<>)).InstancePerRequest();

			builder.RegisterAssemblyTypes(typeof(IImagesRepository).Assembly)
				.Where(t => t.Name.EndsWith("Repository"))
				.AsImplementedInterfaces().InstancePerRequest();
			builder.RegisterAssemblyTypes(typeof(IWundergroundWeatherService).Assembly)
				.AsImplementedInterfaces().InstancePerRequest();

			

			IContainer container = builder.Build();
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}