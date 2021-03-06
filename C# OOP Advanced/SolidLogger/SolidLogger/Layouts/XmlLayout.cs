﻿namespace SolidLogger.Layouts
{
    using SolidLogger.Layouts.Contracts;
    using System;

    public class XmlLayout : ILayout
    {
        public string Format => "<log>\n" +
                                "   <date>{0}</date>\n" +
                                "   <level>{1}</level>\n" +
                                "   <message>{2}</message>\n" + 
                                "</log>";
    }
}
