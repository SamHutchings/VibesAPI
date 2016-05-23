using Ninject;
using System.Web.Http;
using Vibes.Core.Data;
using Vibes.Core.Domain;

namespace Vibes.Web.Api.Controllers
{
	/// <summary>
	/// Base controller for all API controllers
	/// Used to provide authorisation and shared objects
	/// </summary>
	public class BaseApiController : ApiController
	{
		[Inject]
		public IDatabaseSession Session { get; set; }

		public User AuthorisedUser
		{
			get
			{
				return null;
			}
		}
	}
}