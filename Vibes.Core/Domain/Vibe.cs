using System;
using Vibes.Core.Enums;

namespace Vibes.Core.Domain
{
	public class Vibe : DomainObject<Guid>
	{
		public User From { get; set; }

		public User To { get; set; }

		public VibeType Type { get; set; }
	}
}
