using HillelHWCollectionsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary
{
    public class Stack<T> : IStack<T>
    {
        private T[] elements;
        private int count;
        private const int DefaultCapacity = 4;

        public int Count { get { return count; } }

        public Stack()
        {
            elements = new T[DefaultCapacity];
            count = 0;
        }

        public void Push(T item)
        {
            if (count == elements.Length)
            {
                Resize(elements.Length * 2);
            }

            elements[count] = item;
            count++;
        }

        public T Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            count--;
            T item = elements[count];
            elements[count] = default!; 

            if (count > 0 && count == elements.Length / 4)
            {
                Resize(elements.Length / 2);
            }

            return item;
        }

        public void Clear()
        {
            elements = new T[DefaultCapacity];
            count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (elements[i] != null && elements[i]!.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return elements[count - 1];
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = elements[i];
            }

            return array;
        }

        private void Resize(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = elements[i];
            }

            elements = newArray;
        }
    }

}
