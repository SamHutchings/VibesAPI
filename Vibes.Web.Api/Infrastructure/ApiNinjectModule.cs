using FluentNHibernate;
using log4net;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Configuration;
using Vibes.Core.Data;

namespace Vibes.Web.Api.Infrastructure
{
	public class ApiNinjectModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ILog>().ToMethod(context =>
					LogManager.GetLogger(context.Request.ParentContext.Plan.Type));

			Bind<ISessionSource>()
				.ToMethod(x => new SessionSourceFactory().CreateSessionSource(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
				.InSingletonScope();

			Bind<IDatabaseSession>().ToMethod(x => new DatabaseSession(x.Kernel.Get<ISessionSource>().CreateSession()))
				.InRequestScope()
				.OnActivation(session =>
				{
					session.BeginTransaction();
				}).OnDeactivation((context, session) =>
				{
					try
					{
						if (session.Transaction.IsActive)
							session.Transaction.Commit();
					}
					catch (Exception ex)
					{
						Kernel.Get<ILog>().Error(ex);

						session.Transaction.Rollback();
					}
					finally
					{
						if (session.IsOpen)
							session.Close();

						session.Dispose();
					}
				});

		}
	}
}