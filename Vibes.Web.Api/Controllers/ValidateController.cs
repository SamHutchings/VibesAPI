using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vibes.Web.Api.Models;

namespace Vibes.Web.Api.Controllers
{
	public class ValidateController : BaseApiController
	{
		public IHttpActionResult Post(ValidateModel model)
		{
			if (ModelState.IsValid)
			{
				if (AuthorisedUser.ValidationCode != model.ValidationCode)
				{

				}
			}

			return BadRequest(ModelState);
		}
	}
}