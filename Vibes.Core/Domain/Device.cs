using System;

namespace Vibes.Core.Domain
{
	public class Device : DomainObject<Guid>
	{
		public User User { get; set; }

		public string ValidationKey { get; set; }

		public DateTime? ValidationKeySent { get; set; }

		public DateTime? Validated { get; set; }
	}
}
