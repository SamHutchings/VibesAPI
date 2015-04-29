using System;

namespace Vibes.Core.Domain
{
	public class User : DomainObject<Guid>
	{
		public string PhoneNumber { get; set; }
	}
}
