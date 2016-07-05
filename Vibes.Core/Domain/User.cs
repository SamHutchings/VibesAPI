using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Vibes.Core.Extensions;

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
		public virtual string Name { get; set; }

		/// <summary>
		/// The users password
		/// </summary>
		public virtual string Password { get; set; }

		/// <summary>
		/// The salt for the user's password
		/// </summary>
		public virtual string PasswordSalt { get; set; }

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

		/// <summary>
		/// When the user validation expires
		/// </summary>
		public virtual DateTime? ValidationExpires
		{
			get
			{
				if (ValidationCodeSent == null)
					return null;

				return ValidationCodeSent.Value.AddHours(ConfigurationManager.AppSettings["validation-expiry-hours"].ToInt(2));
			}
		}

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
			if (String.IsNullOrWhiteSpace(Name))
				return PhoneNumber;

			return String.Format("{0} ({1})", Name, PhoneNumber);
		}
	}
}
