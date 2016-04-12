using System;
using System.Web.Http.ExceptionHandling;

namespace Vibes.Web.Api.Infrastructure
{
    public class CustomExceptionLogger : ExceptionLogger
    {
        static readonly ILog __log = LogManager.GetLogger(typeof(CustomExceptionLogger));

        public override void Log(ExceptionLoggerContext context)
        {
            var errorTitle = "API Error";
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine(errorTitle);
            sb.AppendLine(new String('=', errorTitle.Length));

            // got a request
            if (context.RequestContext != null)
            {
                // use it
                var request = context.RequestContext;

                sb.AppendFormat("\tUrl: {0}\n", request.Url);

                // got a user
                if (request.Principal != null && request.Principal.Identity != null)
                {
                    sb.AppendFormat("\tUser: {0}\n", request.Principal.Identity.Name);
                }

                sb.AppendFormat("\t:Route Data: {0}\n", request.RouteData);
            }

            __log.Error(sb.ToString(), context.Exception);

            base.Log(context);
        }
    }