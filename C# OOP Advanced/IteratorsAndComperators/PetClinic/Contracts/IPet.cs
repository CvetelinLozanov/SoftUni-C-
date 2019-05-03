using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Contracts
{
    public interface IPet
    {
        string Name { get; }

        int Age { get; }

        string Kind { get; }
    }
}
