using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HotCallsAdmin.UI.Infrastructure;

namespace HotCallsAdmin.UI
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Agencies",
				"{controller}/{action}",
				new { controller = "Agency", action = "Edit" }
			);

			routes.MapRoute(
				"Curents",
				"{controller}/{action}",
				new { controller = "Curent", action = "Edit" }
			);

			routes.MapRoute(
				"Lois",
				"{controller}/{action}",
				new { controller = "Loi", action = "Edit" }
			);

			routes.MapRoute(
				"Priorities",
				"{controller}/{action}",
				new { controller = "Priority", action = "Edit" }
			);

			routes.MapRoute(
				"Types",
				"{controller}/{action}",
				new { controller = "Types", action = "Edit" }
			);

			routes.MapRoute(
				"Users",
				"{controller}/{action}",
				new { controller = "Users", action = "Edit" }
			);

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);

			ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
		}
	}
}