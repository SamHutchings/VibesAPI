using NHibernate;
using System.Linq;

namespace Vibes.Core.Data
{
	public interface IDatabaseSession : ISession
	{
		/// <summary>
		/// Queries the database for type t
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		IQueryable<T> Query<T>();
	}
}
