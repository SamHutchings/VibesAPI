using System.Web.Http;
using Vibes.Core.Data;

namespace Vibes.Web.Api.Controllers
{
	/// <summary>
	/// Base controller for all API controllers
	/// Used to provide authorisation and shared objects
	/// </summary>
	public class BaseApiController : ApiController
	{
		public IDatabaseSession Session { get; set; }
	}
}