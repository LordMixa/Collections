using HillelHWCollectionsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HillelHWCollectionsLibrary
{
    public class SingleLinkedList : ISingleLinkedList
    {
        private Element head;
        private Element tail;
        private int count;
        private class Element
        {
            public object Data;
            public Element Next;

            public Element(object data)
            {
                Data = data;
                Next = null!;
            }
        }
        public virtual int Count => count;
        public virtual object? First { get { return head != null ? head.Data : null; } }
        public virtual object? Last { get { return tail != null ? tail.Data : null; } }
        public SingleLinkedList()
        {
            head = null!;
            tail = null!;
            count = 0;
        }
        public void Add(object value)
        {
            Element newNode = new Element(value);
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
        public void AddFirst(object value)
        {
            Element newNode = new Element(value);

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

        public virtual void Insert(int index, object value)
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
                Element newNode = new Element(value);
                Element current = head!;
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

        public bool Contains(object value)
        {
            Element current = head!;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return true;
                }
                current = current.Next!;
            }
            return false;
        }

        public virtual object[] ToArray()
        {
            object[] array = new object[count];
            Element current = head!;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next!;
            }
            return array;
        }
    }
}
