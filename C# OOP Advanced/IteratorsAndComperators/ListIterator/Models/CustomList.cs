using ListIterator.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListIterator.Models
{
    public class CustomList<T> : ICustomList<T>, IEnumerable<T>
    {
        private T[] elements;

        public CustomList(T[] elements)
        {
            this.elements = elements;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                yield return elements[i];
            }
        }

        public bool HasNext()
        {
            return this.Count < this.elements.Length - 1 ? true : false;
        }

        public bool Move()
        {
            if (this.Count < this.elements.Length - 1)
            {
                this.Count++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.elements.Length != 0)
            {
                Console.WriteLine(this.elements[this.Count]);
                return;
            }

            throw new InvalidOperationException("Invalid Operation!");
        }

        public void PrintAll()
        {
            foreach (var item in elements)
            {
                Console.Write(item + " ");
            } 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
