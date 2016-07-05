using NUnit.Framework;
using System;
using System.Collections;
using Vibes.Core.Domain;

namespace Vibes.Core.Test.Domain
{
	[TestFixture]
	public class UserTest
	{
		[SetUp]
		public void Setup()
		{
			SystemTime.Set(new DateTime(2015, 1, 1, 13, 0, 0));
		}

		[TearDown]
		public void Teardown()
		{
			SystemTime.Reset();
		}

		[TestCase("", "+447931443223", ExpectedResult = "+447931443223")]
		[TestCase("Test Testman", "+447931443223", ExpectedResult = "Test Testman (+447931443223)")]
		public string ToStringReturnsCorrectly(string username, string phoneNumber)
		{
			var user = new User { Name = username, PhoneNumber = phoneNumber };

			return user.ToString();
		}

		[Test, TestCaseSource(typeof(TestGenerateValidationKey), "TestCases")]
		public bool GenerateValidationKeyWorksCorrectly(DateTime? sent, string existingCode)
		{
			var user = new User { ValidationCodeSent = sent, ValidationCode = existingCode };

			user.GenerateValidationKey();

			return user.ValidationCode == existingCode;
		}
	}

	public class TestGenerateValidationKey
	{
		public static IEnumerable TestCases
		{
			get
			{
				yield return new TestCaseData(null, null).Returns(false);
				yield return new TestCaseData(new DateTime(2015, 1, 1, 12, 0, 0), "TEST").Returns(true);
				yield return new TestCaseData(new DateTime(2015, 1, 1, 11, 1, 0), "TEST").Returns(true);
				yield return new TestCaseData(new DateTime(2015, 1, 1, 10, 59, 0), "TEST").Returns(false);
				yield return new TestCaseData(null, "TEST").Returns(false);
			}
		}
	}
}
