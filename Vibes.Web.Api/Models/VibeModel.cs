using System.Web.Http.ModelBinding;
using Vibes.Core.Domain;
using Vibes.Core.Enums;
using Vibes.Web.Api.Infrastructure;

namespace Vibes.Web.Api.Models
{
	public class VibeModel
	{
		public string To { get; set; }

		public VibeType VibeType { get; set; }
	}
}