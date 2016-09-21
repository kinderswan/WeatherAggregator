using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeatherAggregator.WebApi
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class WebApiApplication : System.Web.HttpApplication
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
            log4net.ThreadContext.Properties["SessionID"] = this.Session.SessionID;
            log4net.Config.XmlConfigurator.Configure();
        }
	}
}