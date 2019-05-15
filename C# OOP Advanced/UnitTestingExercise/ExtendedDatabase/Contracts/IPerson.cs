using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedDatabase.Contracts
{
    public interface IPerson : IIdentifiable
    {
        string Username { get; }
    }
}
