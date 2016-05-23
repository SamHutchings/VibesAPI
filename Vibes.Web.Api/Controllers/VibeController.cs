namespace Vibes.Web.Api.Controllers
{
	using Core.Domain;
	using Models;
	using System.Linq;
	using System.Web.Http;

	public class VibeController : BaseApiController
	{
		/// <summary>
		/// Sends the vibe to the specified recipient
		/// </summary>
		/// <param name="vibe"></param>
		/// <returns></returns>
		public IHttpActionResult Post(VibeModel vibe)
		{
			var userTo = Session.Query<User>().Where(x => x.PhoneNumber == vibe.To).FirstOrDefault();

			if (userTo == null)
			{
				ModelState.AddModelError("To", "This user could not be found");

				return BadRequest(ModelState);
			}

			Session.Save(new Vibe { From = AuthorisedUser, To = userTo, Type = vibe.VibeType });

			return Ok();
		}
	}
}
