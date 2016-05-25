using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Vibes.Core.Enums;
using Vibes.Core.Extensions;

namespace Vibes.Core.Test.Extensions
{
	[TestFixture]
	public class TelephoneNumberExtensionsTest
	{
		[TestCase("07931204393", CountryCode.UnitedKingdom, ExpectedResult = "+447931204393")]
		[TestCase("548-542-132", CountryCode.UnitedStatesofAmerica, ExpectedResult = "+1548542132")]
		[TestCase("159753", CountryCode.Afghanistan, ExpectedResult = "+93159753")]
		[TestCase("2554 7891", CountryCode.AmericanSamoa, ExpectedResult = "+168325547891")]
		[TestCase("", CountryCode.AmericanSamoa, ExpectedResult = null)]
		[TestCase(null, CountryCode.Angola, ExpectedResult = null)]
		[TestCase("--", CountryCode.GaboneseRepublic, ExpectedResult = null)]
		[TestCase("000", CountryCode.Russia, ExpectedResult = null)]
		[TestCase("0-0-0", CountryCode.WallisandFutunaIslands, ExpectedResult = null)]
		[TestCase("123", CountryCode.Bangladesh, ExpectedResult = null)]
		public string ToE164ReturnsCorrectly(string number, CountryCode code)
		{
			return number.FormatE164(code);
		}
	}
}
