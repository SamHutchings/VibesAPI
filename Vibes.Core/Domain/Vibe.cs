using System;
using Vibes.Core.Enums;

namespace Vibes.Core.Domain
{
	public class Vibe : DomainObject<Guid>
	{
		public virtual User From { get; set; }

		public virtual User To { get; set; }

		public virtual VibeType Type { get; set; }

		public virtual DateTime? Delivered { get; set; }

		public virtual DateTime? Received { get; set; }
	}
}
