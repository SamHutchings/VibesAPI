using System.Web.Http.ModelBinding;
using Vibes.Core.Domain;
using Vibes.Core.Enums;

namespace Vibes.Web.Api.Models
{
	public class VibeModel
	{
		[ModelBinder(typeof(UserModelBinder))]
		public User To { get; set; }

		public VibeType VibeType { get; set; }
	}
}