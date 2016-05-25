using System.Web.Http;
using Vibes.Web.Api.Models;

namespace Vibes.Web.Api.Controllers
{
	public class AccountController : BaseApiController
	{
		public IHttpActionResult Get()
		{
			return Ok();
		}

		public IHttpActionResult Post(AccountEditModel model)
		{
			return Ok();
		}
	}
}