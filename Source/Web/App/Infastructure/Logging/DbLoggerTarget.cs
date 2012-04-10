using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog.Targets;
using NLog;
using MvcMovie.Models;

namespace MvcMovie.Infastructure.Logging
{

    public class AppLogKeys
    {
        //public const string UserId = "UserId";
        public const string UserName = "UserName";
        public const string IpAddress = "IpAddress";
        public const string Session = "Session";
        public const string Type = "Type";
        public const string Server = "Server";
        public const string Summary = "Summary";
        public const string Browser = "Browser";
    }

    [Target("DbLoggerTarget")]
    public class DbLoggerTarget : TargetWithLayout
    {

        private static string GetLastError()
        {
            Exception ex = HttpContext.Current.Server.GetLastError();
            string s = ex.Message + '\n' + ex.StackTrace;

            if (s == "File does not exist.")
                s = (string.Format("{0} {1}", s, HttpContext.Current.Request.Url.ToString()));

            return s;
        }


        protected override void Write(LogEventInfo logEvent)
        {
            var logLevel = logEvent.Level.ToString();
            var description = ((logLevel == "Error") || (logLevel == "Fatal") || (logLevel == "Warn"))
                            ? ExceptionHelper.GetExceptionDetails(logEvent)
                            : logEvent.FormattedMessage;

            var summary = MappedDiagnosticsContext.Get(AppLogKeys.Summary);
            summary = (string.IsNullOrEmpty(summary))
                ? (description.Length <= 100) ? description : description.Substring(0, 100)
                : (summary.Length <= 100) ? summary : summary.Substring(0, 100);

            var session = MappedDiagnosticsContext.Get(AppLogKeys.Session);
            session = (session != null && session.Length > 8) ? session.Substring(0, 8) : session;

            var appName = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            //var tag = "";
            //var prospectEmail = "";
            //var prospectId = "";

            //Get User IP Address

            var ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
             
            try
            {
                int? id = 0;
                var l = new { };
                
                /* 
                [Description] [nvarchar](MAX) NULL,
                [Summary] [nvarchar](100) NULL,
                [Level] [nvarchar](16) NULL,
                [Logger] [nvarchar](128) NULL,
                [Status] [nvarchar](50) NULL,
                [IpAddress] [nvarchar](100) NULL,
                [Browser] [nvarchar](100) NULL,
                [Server] [nvarchar](100) NULL,
                [Session] [nvarchar](100) NULL,
                [UserName] [nvarchar](100) NULL, 
                [Application] [nvarchar](100) NULL,
                [Type] [nvarchar](100) NULL,
                [Tag] [nvarchar](100),   
                [UpdatedAt] [datetime]  not null default(getdate())  
                */
            }
            catch { } //ignore errors writing to log 
        }

    }
}