using System;

namespace Vibes.Core.Extensions
{
	public static class StringExtensions
	{
		public static int? ToInt(this string value)
		{
			int number;

			if (Int32.TryParse(value, out number))
			{
				return number;
			}

			return null;
		}

		public static int ToInt(this string value, int defaultValue)
		{
			return value.ToInt() ?? defaultValue;
		}
	}
}
