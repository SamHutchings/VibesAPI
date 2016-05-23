using System.Linq;
using System.Web.Http;
using Vibes.Core.Domain;

namespace Vibes.Web.Api.Controllers
{
	public class RegisterController : BaseApiController
	{
		public IHttpActionResult Post(RegisterModel model)
		{
			var 
			var existingUser = Session.Query<User>().Where(x => x.PhoneNumber == phoneNumber);
			return Ok();
		}
	}
}