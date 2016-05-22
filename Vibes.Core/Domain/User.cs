using System;
using System.Collections.Generic;

namespace Vibes.Core.Domain
{
	public class User : DomainObject<int>
	{
		/// <summary>
		/// The user's phone number. This is their unique identifier
		/// </summary>
		public virtual string PhoneNumber { get; set; }

		/// <summary>
		/// The users name. Displayed to others
		/// </summary>
		public virtual string Username { get; set; }

		/// <summary>
		/// The current device id for the user
		/// </summary>
		public virtual string DeviceId { get; set; }

		/// <summary>
		/// The validation key the user is sent to validate their phone number
		/// </summary>
		public virtual string ValidationKey { get; set; }

		/// <summary>
		/// When the validation key was sent to the user
		/// </summary>
		public virtual DateTime? ValidationKeySent { get; set; }

		/// <summary>
		/// When the user was validated
		/// </summary>
		public virtual DateTime? Validated { get; set; }
	}
}
