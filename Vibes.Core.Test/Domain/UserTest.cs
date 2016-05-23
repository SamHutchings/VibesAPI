using NUnit.Framework;
using Vibes.Core.Domain;

namespace Vibes.Core.Test.Domain
{
	[TestFixture]
	public class UserTest
	{
		[TestCase("", "+447931443223", ExpectedResult = "+447931443223")]
		[TestCase("Test Testman", "+447931443223", ExpectedResult = "Test Testman (+447931443223)")]
		public string ToStringReturnsCorrectly(string username, string phoneNumber)
		{
			var user = new User { Username = username, PhoneNumber = phoneNumber };

			return user.ToString();
		}
	}
}
