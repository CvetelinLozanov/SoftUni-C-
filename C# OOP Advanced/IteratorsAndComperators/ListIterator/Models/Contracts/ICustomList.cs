using System;
using System.Collections.Generic;
using System.Text;

namespace ListIterator.Models.Contracts
{
    public interface ICustomList<T>
    {
        bool HasNext();

        bool Move();

        void Print();

        void PrintAll();

        int Count { get; }
    }
}
