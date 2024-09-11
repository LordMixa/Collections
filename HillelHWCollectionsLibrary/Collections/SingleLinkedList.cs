using HillelHWCollectionsLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HillelHWCollectionsLibrary.Collections
{
    public class SingleLinkedList<T> : ISingleLinkedList<T>
    {
        private SingleLinkedListNode<T> head;
        private SingleLinkedListNode<T> tail;
        private int count;
        protected class SingleLinkedListNode<T>
        {
            public T Data { get; }
            public SingleLinkedListNode<T> Next { get; set; }

            public SingleLinkedListNode(T data)
            {
                Data = data;
                Next = null!;
            }
        }
        public virtual int Count => count;
        public virtual T? First { get { return head != null ? head.Data : default; } }
        public virtual T? Last { get { return tail != null ? tail.Data : default; } }
        public SingleLinkedList()
        {
            head = null!;
            tail = null!;
            count = 0;
        }
        public void Add(T value)
        {
            SingleLinkedListNode<T> newNode = new SingleLinkedListNode<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                tail = newNode;
            }
            count++;
        }
        public void AddFirst(T value)
        {
            SingleLinkedListNode<T> newNode = new SingleLinkedListNode<T>(value);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            count++;
        }

        public virtual void Insert(int index, T value)
        {
            if (index < 0 || index > count) throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == count)
            {
                Add(value);
            }
            else
            {
                SingleLinkedListNode<T> newNode = new SingleLinkedListNode<T>(value);
                SingleLinkedListNode<T> current = head!;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next!;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                count++;
            }
        }

        public virtual void Clear()
        {
            head = null!;
            tail = null!;
            count = 0;
        }

        public bool Contains(T value)
        {
            SingleLinkedListNode<T> current = head!;
            while (current != null)
            {
                if (current.Data!.Equals(value))
                {
                    return true;
                }
                current = current.Next!;
            }
            return false;
        }

        public virtual T[] ToArray()
        {
            T[] array = new T[count];
            SingleLinkedListNode<T> current = head!;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next!;
            }
            return array;
        }
        public IEnumerator<T> GetEnumerator()
        {
            SingleLinkedListNode<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //public IEnumerator<T> GetEnumerator()
        //{
        //    return new SingleLinkedListIterator<T>(this);
        //}
        //private class SingleLinkedListIterator<T> : IEnumerator<T>
        //{
        //    private readonly SingleLinkedList<T> list;
        //    private SingleLinkedList<T>.SingleLinkedListNode<T>? currentNode = null;

        //    public T Current { get => currentNode != null ? currentNode.Data : default; }

        //    object IEnumerator.Current => Current;

        //    public SingleLinkedListIterator(SingleLinkedList<T> list)
        //    {
        //        this.list = list;
        //    }

        //    public bool MoveNext()
        //    {
        //        if (currentNode == null)
        //        {
        //            currentNode = list.head;
        //        }
        //        else
        //        {
        //            currentNode = currentNode.Next;
        //        }

        //        return currentNode != null;
        //    }

        //    public void Reset()
        //    {
        //        currentNode = null;
        //    }

        //    public void Dispose()
        //    {
        //    }
        //}
    }
}
