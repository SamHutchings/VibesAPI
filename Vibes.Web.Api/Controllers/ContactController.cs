using Vibes.Core.Data;

namespace Vibes.Web.Api.Controllers
{
	public class ContactController : BaseApiController
	{
		public ContactController(IDatabaseSession session) : base(session) { }
	}
}
