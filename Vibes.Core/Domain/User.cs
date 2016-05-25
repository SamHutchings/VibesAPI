using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vibes.Core.Domain
{
	public class User : DomainObject<int>
	{
		/// <summary>
		/// The user's phone number. This is their unique identifier
		/// </summary>
		[DataType(DataType.PhoneNumber)]
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
		[StringLength(10)]
		public virtual string ValidationCode { get; set; }

		/// <summary>
		/// When the validation key was sent to the user
		/// </summary>
		public virtual DateTime? ValidationCodeSent { get; set; }

		/// <summary>
		/// When the user was validated
		/// </summary>
		public virtual DateTime? Validated { get; set; }

		public virtual void GenerateValidationKey()
		{
			if (ValidationCodeSent == null || ValidationCodeSent.Value.AddHours(2) < SystemTime.Now)
			{
				ValidationCode = Guid.NewGuid().ToString().Substring(0, 6);
				ValidationCodeSent = SystemTime.Now;
			}
		}

		public override string ToString()
		{
			if (String.IsNullOrWhiteSpace(Username))
				return PhoneNumber;

			return String.Format("{0} ({1})", Username, PhoneNumber);
		}
	}
}
