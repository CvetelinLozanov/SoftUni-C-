using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedDatabase.Contracts
{
    public interface IIdentifiable
    {
        long Id { get; }
    }
}
