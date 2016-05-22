using NUnit.Framework;
using Vibes.Core.Domain;

namespace Vibes.Core.Test.Domain
{
	[TestFixture]
	public class UserTest
	{
		public string ToStringReturnsCorrectly(string username, string phoneNumber)
		{
			var user = new User { Username = username, PhoneNumber = phoneNumber };

			return user.ToString();
		}
	}
}
