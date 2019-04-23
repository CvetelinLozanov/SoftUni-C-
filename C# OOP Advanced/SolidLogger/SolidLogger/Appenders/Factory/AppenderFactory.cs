namespace SolidLogger.Appenders.Factory
{
    
    using SolidLogger.Appenders.Contracts;
    using SolidLogger.Appenders.Factory.Contracts;
    using SolidLogger.Layouts.Contracts;
    using SolidLogger.Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLowerCase = type.ToLower();

            switch (typeAsLowerCase)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
