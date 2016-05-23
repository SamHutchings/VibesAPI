using System.Linq;
using System.Web.Http;
using Vibes.Core.Domain;

namespace Vibes.Web.Api.Controllers
{
	public class AccountController : BaseApiController
	{
		public IHttpActionResult Post(string phoneNumber)
		{
			var existingUser = Session.Query<User>().Where(x => x.PhoneNumber == phoneNumber);
			return Ok();
		}
	}
}