using System;

namespace Vibes.Core.Domain
{
	public class User : DomainObject<int>
	{
		/// <summary>
		/// The user's phone number. This is their unique identifier
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// The users name. Displayed to others
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// The current device id for the user
		/// </summary>
		public string DeviceId { get; set; }

		/// <summary>
		/// The validation key the user is sent to validate their phone number
		/// </summary>
		public string ValidationKey { get; set; }

		/// <summary>
		/// When the validation key was sent to the user
		/// </summary>
		public DateTime? ValidationKeySent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? Validated { get; set; }
	}
}
