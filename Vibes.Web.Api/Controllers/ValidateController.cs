using System.Web.Http;
using Vibes.Core;
using Vibes.Web.Api.Models;

namespace Vibes.Web.Api.Controllers
{
	public class ValidateController : BaseApiController
	{
		public IHttpActionResult Post(ValidateModel model)
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
	}
}