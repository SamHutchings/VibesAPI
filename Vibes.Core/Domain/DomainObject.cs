using System;

namespace Vibes.Core.Domain
{
	/// <summary>
	/// Base database object
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class DomainObject<T>
	{
		public T Id { get; set; }

		public DateTime Created { get; }
	}
}
