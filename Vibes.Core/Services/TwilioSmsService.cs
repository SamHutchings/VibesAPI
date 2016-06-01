using log4net;
using System;
using System.Configuration;
using Twilio;
using Vibes.Core.Domain;

namespace Vibes.Core.Services
{
	public class TwilioSmsService : ISmsService
	{
		private ILog _log;

		private static string __apiKey;
		private static string __authToken;

		public TwilioSmsService(ILog log)
		{
			_log = log;

			__apiKey = ConfigurationManager.AppSettings["twilio-sms-key"];
			__authToken = ConfigurationManager.AppSettings["twilio-auth-token"];
		}

		public bool SendVerification(User user)
		{
			if (user.Validated != null)
				return false;

			if (String.IsNullOrWhiteSpace(user.ValidationCode))
				return false;

			if (user.ValidationExpires < SystemTime.Now)
				return false;

			try
			{
				var twilioService = new TwilioRestClient(__apiKey, __authToken);

				var message = twilioService.SendMessage(
					"VIBES",
					user.PhoneNumber,
					String.Format("Your code is {0}", user.ValidationCode)
				);
			}
			catch (Exception ex)
			{
				_log.ErrorFormat("Could not send verification message to {0}: {1}", user, ex);

				return false;
			}

			return true;
		}
	}
}
