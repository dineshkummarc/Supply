using System;
using System.Text;
using System.Web;

namespace MvcMovie.Infastructure.Logging
{
    public class ExceptionHelper
    {
        /// <summary>
        /// This expects a web context; without it, the method will exit early.
        /// </summary>
        /// <param name="logEvent"></param>
        /// <returns></returns>
        public static string GetExceptionDetails(NLog.LogEventInfo logEvent)
        {
            if (HttpContext.Current == null
                || HttpContext.Current.Request == null
                || HttpContext.Current.Server == null) { return ""; }

            var serverVariables = HttpContext.Current.Request.ServerVariables;
            var lastError = HttpContext.Current.Server.GetLastError();

            string errorMessage = (lastError == null) ? logEvent.FormattedMessage : lastError.InnerException.ToString();  

            var errorDetails = new StringBuilder();



            errorDetails.AppendFormat("{0}<br /><br />", errorMessage);
            // This helps give meaningful data in the case of "File does not exist" errors
            errorDetails.AppendFormat("File Path: {0}<br /><br />", HttpContext.Current.Request.FilePath);



            // Stack trace
            if (logEvent.StackTrace != null)
                errorDetails.AppendFormat("<i>Stack Trace:</i><br />{0}<br /><br />", logEvent.StackTrace.ToString());
            else if (logEvent.Exception != null)
                errorDetails.AppendFormat("<i>Stack Trace:</i><br />{0}<br /><br />", logEvent.Exception.Message + logEvent.Exception.StackTrace.ToString());

            // Server variables
            errorDetails.AppendFormat("<i>Server Variables:</i><br />");

            foreach (String s in serverVariables.AllKeys)
                errorDetails.AppendFormat("<p><span>{0,-10}<span>: <b>{1}</b></p>", s, serverVariables[s]);

            return errorDetails.ToString();
        }
    }
}