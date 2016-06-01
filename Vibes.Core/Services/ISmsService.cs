using Vibes.Core.Domain;

namespace Vibes.Core.Services
{
	public interface ISmsService
	{
		bool SendVerification(User user);
	}
}
