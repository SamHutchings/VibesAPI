using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
namespace Vibes.Core.Data
{
	public class SessionSourceFactory
	{
		public ISessionSource CreateSessionSource(string connectionString)
		{
			var dbProperties = PostgreSQLConfiguration
				.PostgreSQL82
				.ConnectionString(connectionString)
				.ToProperties();

			return new SessionSource(dbProperties, new CustomPersistenceModel());
		}
	}
}
