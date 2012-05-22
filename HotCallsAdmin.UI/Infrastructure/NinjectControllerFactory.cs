using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Modules;
using System.Configuration;
using HotCallsAdmin.Domain.Abstract;
using HotCallsAdmin.Domain.Concrete;

namespace HotCallsAdmin.UI.Infrastructure
{
	public class NinjectControllerFactory : DefaultControllerFactory
	{
		// A Ninject "kernel" is the thing that can supply object instances
		private IKernel kernel = new StandardKernel(new HotCallsServices());

		// ASP.NET MVC calls this to get the controller for each request
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
				return null;
			return (IController)kernel.Get(controllerType);
		}

		// Configures how abstract service types are mapped to concrete implementations
		private class HotCallsServices : NinjectModule
		{
			public override void Load()
			{
				Bind<IUsersRepository>()
					.To<OracleUsersRepository>()
					.WithConstructorArgument("connectionString",
					ConfigurationManager.ConnectionStrings["HotCalls"].ConnectionString
					);

				Bind<IAgenciesRepository>()
					.To<OracleAgenciesRepository>()
					.WithConstructorArgument("connectionString",
					ConfigurationManager.ConnectionStrings["HotCalls"].ConnectionString
					);

				Bind<ICurentsRespository>()
					.To<OracleCurentsRepository>()
					.WithConstructorArgument("connectionString",
					ConfigurationManager.ConnectionStrings["HotCalls"].ConnectionString
					);

				Bind<ILoisRepository>()
					.To<OracleLoisRepository>()
					.WithConstructorArgument("connectionString",
					ConfigurationManager.ConnectionStrings["HotCalls"].ConnectionString
					);

				Bind<IPrioritiesRepository>()
					.To<OraclePrioritiesRepository>()
					.WithConstructorArgument("connectionString",
					ConfigurationManager.ConnectionStrings["HotCalls"].ConnectionString
					);

				Bind<ISentsRepository>()
					.To<OracleSentsRepository>()
					.WithConstructorArgument("connectionString",
					ConfigurationManager.ConnectionStrings["HotCalls"].ConnectionString
					);

				Bind<ITypesRepository>()
					.To<OracleTypesRepository>()
					.WithConstructorArgument("connectionString",
					ConfigurationManager.ConnectionStrings["HotCalls"].ConnectionString
					);
			}
		}
	}
}
