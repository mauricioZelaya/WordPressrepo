using Serilog;
using System.IO;

namespace WordPress.Logger
{
    public sealed class LoggerManager
    {
        private static string LoggerReportPath = @"C:\Results\";

        private LoggerManager()
        {
            const string customTemplate = "{Timestamp:yyyy-MMM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}";
            const string loggerFileName = @"WPLogs.txt";

            var fullPath = Path.Combine(LoggerReportPath, loggerFileName);

            Log.Logger = new LoggerConfiguration()
                    .WriteTo.RollingFile(fullPath, outputTemplate: customTemplate)
                    .CreateLogger();
        }

        public void Information(string message)
        {
            Log.Information(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }
        
        private static LoggerManager _instance;
        public static LoggerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoggerManager();
                }

                return _instance;
            }
        }
    }
}
