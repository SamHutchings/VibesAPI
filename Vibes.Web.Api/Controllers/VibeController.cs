namespace Vibes.Web.Api.Controllers
{
	using System.Web.Http;
	using Core.Domain;
	using System;

	public class VibeController : ApiController
	{
		/// <summary>
		/// Sends the vibe to the specified recipient
		/// </summary>
		/// <param name="vibe"></param>
		/// <returns></returns>
		public IHttpActionResult Post(Vibe vibe)
		{
			throw new NotImplementedException();
		}
	}
}
