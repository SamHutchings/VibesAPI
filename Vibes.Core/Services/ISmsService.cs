using Vibes.Core.Domain;

namespace Vibes.Core.Services
{
	public interface ISmsService
	{
		bool SendValidation(User user);
	}
}
