using System;
using System.Text.RegularExpressions;
using Vibes.Core.Enums;

namespace Vibes.Core.Extensions
{
	public static class PhoneNumberExtensions
	{
		private static readonly Regex __numberRegex = new Regex("[^0-9]", RegexOptions.Compiled);

		public static string FormatE164(this string number, CountryCode code)
		{
			if (String.IsNullOrWhiteSpace(number))
				return null;

			var trimmedNumber = number.TrimStart('0');

			if (String.IsNullOrWhiteSpace(trimmedNumber))
				return null;

			trimmedNumber = __numberRegex.Replace(trimmedNumber, "");

			if (trimmedNumber.Length < 5 || trimmedNumber.Length > 14)
				return null;

			return String.Format("+{0}{1}", (int)code, trimmedNumber);
		}
	}
}
