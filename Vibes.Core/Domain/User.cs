using System.Collections.Generic;

namespace Vibes.Core.Domain
{
	public class User : DomainObject<int>
	{
		public string PhoneNumber { get; set; }

		public ISet<Device> Devices { get; set; }

		public User()
		{
			Devices = new HashSet<Device>();
		}
	}
}
