using System.ComponentModel.DataAnnotations;

namespace Vibes.Web.Api.Models
{
	public class ValidateModel
	{
		[Required(ErrorMessage = "Please enter your validation code")]
		public string ValidationCode { get; set; }
	}
}