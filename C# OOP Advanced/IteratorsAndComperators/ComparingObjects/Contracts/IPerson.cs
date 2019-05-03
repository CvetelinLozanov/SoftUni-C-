using System;
using System.Collections.Generic;
using System.Text;

namespace ComparingObjects.Contracts
{
    public interface IPerson
    {
        string Name { get; set; }

        int Age { get; set; }

        string Town { get; set; }
    }
}
