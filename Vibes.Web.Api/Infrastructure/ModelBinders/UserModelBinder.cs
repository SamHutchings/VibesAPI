using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Vibes.Core.Domain;

namespace Vibes.Web.Api.Infrastructure
{
	/// <summary>
	/// Binds to a user based on the telephone number
	/// </summary>
	public class UserModelBinder : IModelBinder
	{
		public ISession _session;

		public UserModelBinder(ISession session)
		{
			_session = session;
		}

		public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
		{
			var phoneNumber = bindingContext.ValueProvider.GetValue("").AttemptedValue;

			if (String.IsNullOrWhiteSpace(phoneNumber))
			{
				bindingContext.Model = null;

				return false;
			}

			bindingContext.Model = _session.Query<User>().Where(x => x.PhoneNumber == phoneNumber).FirstOrDefault();

			return true;
		}
	}
}