using System;

namespace Vibes.Core.Domain
{
	/// <summary>
	/// Base database object
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class DomainObject<T>
	{
		public virtual T Id { get; set; }

		public virtual DateTime Created { get; }
	}
}
