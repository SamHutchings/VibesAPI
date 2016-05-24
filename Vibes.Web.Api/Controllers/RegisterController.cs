using System.Linq;
using System.Web.Http;
using Vibes.Core.Domain;
using Vibes.Web.Api.Models;

namespace Vibes.Web.Api.Controllers
{
	[AllowAnonymous]
	public class RegisterController : BaseApiController
	{
		public IHttpActionResult Post(RegisterModel model)
		{
			if (ModelState.IsValid)
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

				user.GenerateValidationKey();

				return Ok(model);
			}

			return BadRequest(ModelState);
		}
	}
}