using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary
{
    public class Queue
    {
        private object[] elements;
        private int head;
        private int tail;
        private int count;
        private const int DefaultCapacity = 4;

        public int Count { get { return count; } }

        public Queue()
        {
            elements = new object[DefaultCapacity];
            head = 0;
            tail = 0;
            count = 0;
        }

        public void Enqueue(object item)
        {
            if (count == elements.Length)
            {
                Resize(elements.Length * 2);
            }

            elements[tail] = item;
            tail = (tail + 1) % elements.Length;
            count++;
        }

        public object Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            object item = elements[head];
            elements[head] = null!;
            head = (head + 1) % elements.Length;
            count--;

            if (count > 0 && count == elements.Length / 4)
            {
                Resize(elements.Length / 2);
            }

            return item;
        }

        public void Clear()
        {
            elements = new object[DefaultCapacity];
            head = 0;
            tail = 0;
            count = 0;
        }

        public bool Contains(object item)
        {
            int index = head;
            int itemsChecked = 0;

            while (itemsChecked < count)
            {
                if (elements[index] != null && elements[index].Equals(item))
                {
                    return true;
                }

                index = (index + 1) % elements.Length;
                itemsChecked++;
            }

            return false;
        }

        public object Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return elements[head];
        }

        public object[] ToArray()
        {
            object[] array = new object[count];
            int index = head;

            for (int i = 0; i < count; i++)
            {
                array[i] = elements[index];
                index = (index + 1) % elements.Length;
            }

            return array;
        }

        private void Resize(int newCapacity)
        {
            object[] newArray = new object[newCapacity];

            for (int i = 0; i < count; i++)
            {
                newArray[i] = elements[(head + i) % elements.Length];
            }

            elements = newArray;
            head = 0;
            tail = count;
        }
    }
}
