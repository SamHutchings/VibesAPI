using System;
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
			throw new NotImplementedException();
		}

		public bool UserExists(string username)
		{
			throw new NotImplementedException();
		}

		public User ValidateUser(string username, string password)
		{
			throw new NotImplementedException();
		}
	}
}