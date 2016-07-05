using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vibes.Core.Enums;
using Vibes.Core.Extensions;

namespace Vibes.Web.Api.Models
{
	public class RegisterModel : IValidatableObject
	{
		[Required(ErrorMessage = "Please enter your telephone number")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Please provide a password")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Please enter your country")]
		public CountryCode? CountryCode { get; set; }

		public string FormattedPhoneNumber
		{
			get
			{
				if (CountryCode == null || String.IsNullOrWhiteSpace(PhoneNumber))
					return null;

				return PhoneNumber.FormatE164(CountryCode.Value);
			}
		}

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (String.IsNullOrWhiteSpace(FormattedPhoneNumber))
			{
				yield return new ValidationResult("Please enter a valid phone number", new[] { "PhoneNumber" });
			}
		}
	}
}