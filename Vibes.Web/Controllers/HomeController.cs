using System.Web.Mvc;

namespace Vibes.Web.Controllers
{
	public class HomeController : Controller
	{
		/// <summary>
		/// Takes a phone number and sends a verification text 
		/// </summary>
		/// <param name="phoneNumber"></param>
		public void SendVerificationMessage(string phoneNumber)
		{
			// check phone number is valid

			// send verification text
		}

		/// <summary>
		/// Called from the app to verify that the user phone number is valid
		/// </summary>
		/// <param name="phoneNumber"></param>
		public void VerifyPhone(string phoneNumber)
		{
			// create new user and device

			// save to db
		}

		/// <summary>
		/// Given a list of phone numbers, fetches all users from db and returns them
		/// </summary>
		public void GetExistingUsers()
		{
			// fetch all users from db where in phonebook

			// serialise to json

			// send back
		}

		/// <summary>
		/// Attempst to send a vibe of the given type to the given user
		/// </summary>
		public void SendVibe()
		{
			// create vibe 

			// send to touser

			// save to db if successful
		}
	}
}
