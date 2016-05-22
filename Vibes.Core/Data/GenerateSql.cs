using NHibernate.Tool.hbm2ddl;

namespace Vibes.Core.Data
{
	/// <summary>
	/// Generates create and update sql documents
	/// </summary>
	public class GenerateSql
	{
		public static string DefaultConnectionString { get { return "Server=localhost;database=vibes;user id=postgres;password=gr8Vib3s;"; } }

		/// <summary>
		/// Generates the create schema
		/// </summary>
		public static void ScriptCreateSchema()
		{
			var source = new SessionSourceFactory().CreateSessionSource(DefaultConnectionString);

			new SchemaExport(source.Configuration).Execute(true, false, false);
		}

		/// <summary>
		/// Generates the update schema 
		/// </summary>
		public static void ScriptUpdateSchema()
		{
			var source = new SessionSourceFactory().CreateSessionSource(DefaultConnectionString);

			new SchemaUpdate(source.Configuration).Execute(true, false);
		}
	}
}
