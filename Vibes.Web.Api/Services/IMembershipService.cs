using Vibes.Core.Domain;

namespace Vibes.Web.Api.Services
{
	public interface IMembershipService
	{
		User RegisterUser(string username, string password);

		User ValidateUser(string username, string password);

		User CurrentUser();

		bool UserExists(string username);

		bool ChangePassword(string username, string oldPassword, string newPassword);
	}
}