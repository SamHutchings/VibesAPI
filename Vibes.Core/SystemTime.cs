using System;

namespace Vibes.Core
{
	/// <summary>
	/// System time to assist testing
	/// </summary>
	public static class SystemTime
	{
		private static Func<DateTime> now = () => DateTime.Now;

		public static DateTime Now
		{
			get { return now(); }
		}

		public static void Set(DateTime dt)
		{
			now = () => dt;
		}

		public static void Reset()
		{
			now = () => DateTime.Now;
		}
	}
}
