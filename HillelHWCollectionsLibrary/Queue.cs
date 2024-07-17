using HillelHWCollectionsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary
{
    public class Queue<T> : IQueue<T>
    {
        private T[] elements;
        private int head;
        private int tail;
        private int count;
        private const int DefaultCapacity = 4;

        public int Count { get { return count; } }

        public Queue()
        {
            elements = new T[DefaultCapacity];
            head = 0;
            tail = 0;
            count = 0;
        }

        public void Enqueue(T item)
        {
            if (count == elements.Length)
            {
                Resize(elements.Length * 2);
            }

            elements[tail] = item;
            tail = (tail + 1) % elements.Length;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = elements[head];
            elements[head] = default!;
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
            elements = new T[DefaultCapacity];
            head = 0;
            tail = 0;
            count = 0;
        }

        public bool Contains(T item)
        {
            int index = head;
            int itemsChecked = 0;

            while (itemsChecked < count)
            {
                if (elements[index] != null && elements[index]!.Equals(item))
                {
                    return true;
                }

                index = (index + 1) % elements.Length;
                itemsChecked++;
            }

            return false;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return elements[head];
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
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
            T[] newArray = new T[newCapacity];

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
