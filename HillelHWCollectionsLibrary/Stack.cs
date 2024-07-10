using HillelHWCollectionsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary
{
    public class Stack : IStack
    {
        private object[] elements;
        private int count;
        private const int DefaultCapacity = 4;

        public int Count { get { return count; } }

        public Stack()
        {
            elements = new object[DefaultCapacity];
            count = 0;
        }

        public void Push(object item)
        {
            if (count == elements.Length)
            {
                Resize(elements.Length * 2);
            }

            elements[count] = item;
            count++;
        }

        public object Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            count--;
            object item = elements[count];
            elements[count] = null!; 

            if (count > 0 && count == elements.Length / 4)
            {
                Resize(elements.Length / 2);
            }

            return item;
        }

        public void Clear()
        {
            elements = new object[DefaultCapacity];
            count = 0;
        }

        public bool Contains(object item)
        {
            for (int i = 0; i < count; i++)
            {
                if (elements[i] != null && elements[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public object Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return elements[count - 1];
        }

        public object[] ToArray()
        {
            object[] array = new object[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = elements[i];
            }

            return array;
        }

        private void Resize(int newCapacity)
        {
            object[] newArray = new object[newCapacity];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = elements[i];
            }

            elements = newArray;
        }
    }

}
