namespace SolidLogger.Loggers
{
    using SolidLogger.Appenders.Contracts;
    using SolidLogger.Loggers.Contracts;
    using SolidLogger.Loggers.Enums;
    using System;

    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            :this(consoleAppender)
        {           
            this.fileAppender = fileAppender;
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.ERROR, errorMessage);          
        }
      
        public void Info(string dateTime, string infoMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.INFO, infoMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.CRITICAL, criticalMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.FATAL, fatalMessage);
        }

        public void Warning(string dateTime, string warningMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.FATAL, warningMessage);
        }

        private void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            this.fileAppender?.Append(dateTime, reportLevel, message);
            this.consoleAppender?.Append(dateTime, reportLevel, message);
        }

    }
}
