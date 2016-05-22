using Vibes.Core.Enums;

namespace Vibes.Web.Api.Models
{
	public class IncomingVibe
	{
		public string To { get; set; }

		public VibeType VibeType { get; set; }
	}
}