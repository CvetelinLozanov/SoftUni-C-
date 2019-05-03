namespace CustomStack.SoftUniStack.Contracts
{

    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISoftUniStack<T>
    {
        void Push(T element);

        T Pop();
    }
}
