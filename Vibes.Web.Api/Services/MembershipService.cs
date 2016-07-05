using System;
using System.Security.Cryptography;
using System.Text;
using Vibes.Core.Domain;

namespace Vibes.Web.Api.Services
{
	public class MembershipService : IMembershipService
	{
		public bool ChangePassword(string username, string oldPassword, string newPassword)
		{
			throw new NotImplementedException();
		}

		public User CurrentUser()
		{
			throw new NotImplementedException();
		}

		public User RegisterUser(string username, string password)
		{
			var user = new User
			{
				PhoneNumber = username,
				PasswordSalt = GetSalt()
			};

			user.Password = SaltPassword(password, user.PasswordSalt);

			return user;
		}

		public bool UserExists(string username)
		{
			throw new NotImplementedException();
		}

		public User ValidateUser(string username, string password)
		{
			throw new NotImplementedException();
		}

		string SaltPassword(string password, string passwordSalt)
		{
			var passwordBytes = UnicodeEncoding.Unicode.GetBytes(password);
			var saltBytes = UnicodeEncoding.Unicode.GetBytes(password);

			var hashAlgorithm = new HMACSHA256(saltBytes);

			return UnicodeEncoding.Unicode.GetString(hashAlgorithm.ComputeHash(passwordBytes));
		}

		string GetSalt()
		{
			byte[] salt = new byte[32];
			RNGCryptoServiceProvider.Create().GetBytes(salt);

			return UnicodeEncoding.Unicode.GetString(salt);
		}
	}
}