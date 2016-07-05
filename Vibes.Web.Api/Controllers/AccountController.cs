using Ninject;
using System.Linq;
using System.Web.Http;
using Vibes.Core;
using Vibes.Core.Domain;
using Vibes.Core.Services;
using Vibes.Web.Api.Models;
using Vibes.Web.Api.Services;

namespace Vibes.Web.Api.Controllers
{
	public class AccountController : BaseApiController
	{
		[Inject]
		public ISmsService SmsService { get; set; }

		[Inject]
		public IMembershipService MembershipService { get; set; }

		public IHttpActionResult Get()
		{
			return Ok();
		}

		public IHttpActionResult Post(AccountEditModel model)
		{
			return Ok();
		}

		[AllowAnonymous]
		public IHttpActionResult Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				var user = GetUnvalidatedUser(model);

				if (user == null)
					return BadRequest("User already validated");

				user.GenerateValidationKey();

				if (!SmsService.SendValidation(user))
					return BadRequest("Unable to send validation message, please try again");

				return Ok(model);
			}

			return BadRequest(ModelState);
		}

		public IHttpActionResult Validate(ValidateModel model)
		{
			if (ModelState.IsValid)
			{
				if (AuthorisedUser.Validated != null)
					return Ok();

				if (AuthorisedUser.ValidationCode == model.ValidationCode && AuthorisedUser.ValidationExpires >= SystemTime.Now)
				{
					AuthorisedUser.Validated = SystemTime.Now;

					return Ok(model);
				}

				ModelState.AddModelError("ValidationCode", "We couldn't find this code");
			}

			return BadRequest(ModelState);
		}

		User GetUnvalidatedUser(RegisterModel model)
		{
			var user = Session.Query<User>().Where(x => x.PhoneNumber == model.FormattedPhoneNumber).FirstOrDefault();

			if (user == null)
			{
				user = MembershipService.RegisterUser(model.FormattedPhoneNumber, model.Password);
			}

			if (user.Validated != null)
				return null;

			return user;
		}
	}
}