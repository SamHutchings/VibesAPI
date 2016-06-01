using Ninject;
using System.Linq;
using System.Web.Http;
using Vibes.Core.Domain;
using Vibes.Core.Services;
using Vibes.Web.Api.Models;

namespace Vibes.Web.Api.Controllers
{
	[AllowAnonymous]
	public class RegisterController : BaseApiController
	{
		[Inject]
		public ISmsService SmsService { get; set; }

		public IHttpActionResult Post(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				var user = GetUser(model);

				if (user == null)
					return BadRequest("User already validated");

				user.GenerateValidationKey();

				if (!SmsService.SendVerification(user))
					return BadRequest("Unable to send verification message, please try again");

				return Ok(model);
			}

			return BadRequest(ModelState);
		}

		User GetUser(RegisterModel model)
		{
			var user = Session.Query<User>().Where(x => x.PhoneNumber == model.FormattedPhoneNumber).FirstOrDefault();

			if (user == null)
			{
				user = new User
				{
					PhoneNumber = model.FormattedPhoneNumber
				};

				Session.Save(user);
			}

			if (user.Validated != null)
				return null;

			return user;
		}
	}
}