using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibes.Core.Data
{
	/// <summary>
	/// Creates session sources
	/// </summary>
	public class SessionSourceFactory
	{
		/// <summary>
		/// Create the session source for the given connection string
		/// </summary>
		/// <param name="connectionString"></param>
		/// <returns></returns>
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
