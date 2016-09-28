using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using log4net.Config;

namespace WeatherAggregator.WebApi
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			Bootstrapper.Run();
			GlobalConfiguration.Configuration.EnsureInitialized();
		}

		protected void Session_Start(object sender, EventArgs e)
		{
			ThreadContext.Properties["SessionID"] = Guid.NewGuid();
			XmlConfigurator.Configure();
		}
	}
}