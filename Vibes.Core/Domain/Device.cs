using System;

namespace Vibes.Core.Domain
{
	public class Device : DomainObject<Guid>
	{
		public User User { get; set; }
	}
}
