namespace SolidLogger.Appenders.Factory.Contracts
{
    using SolidLogger.Appenders.Contracts;
    using SolidLogger.Layouts.Contracts;
    using System;

    interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
