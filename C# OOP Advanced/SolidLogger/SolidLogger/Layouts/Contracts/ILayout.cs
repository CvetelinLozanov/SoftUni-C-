using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Layouts.Contracts
{
    public interface ILayout
    {
        string Format { get;  }
    }
}
