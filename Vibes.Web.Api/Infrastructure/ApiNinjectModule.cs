using FluentNHibernate;
using Ninject;
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
			Bind<ISessionSource>()
				.ToMethod(x => new SessionSourceFactory().CreateSessionSource(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
				.InSingletonScope();

			// the session, one done per request
			Bind<IDatabaseSession>().ToMethod(x => new DatabaseSession(x.Kernel.Get<ISessionSource>().CreateSession()))
				.InRequestScope()
				.OnActivation(session =>
				{
					// check we've no active trans
					if (!session.Transaction.IsActive)
						// if not, begin one
						session.BeginTransaction();
				})
				.OnDeactivation((context, session) =>
				{
					try
					{
						// check we have an active transaction and commit if necessary
						if (session.Transaction.IsActive)
							session.Transaction.Commit();
					}
					catch (Exception ex)
					{
						session.Transaction.Rollback();
					}
					finally
					{
						// close
						if (session.IsOpen)
							session.Close();

						// and dispose
						session.Dispose();
					}
				});

		}
	}
}