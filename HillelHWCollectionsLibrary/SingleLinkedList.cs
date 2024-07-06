using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HillelHWCollectionsLibrary
{
    public class SingleLinkedList
    {
        protected Node head;
        protected Node tail;
        protected int count;
        protected class Node
        {
            public object Data;
            public Node Next;
            public Node Previous;


            public Node(object data)
            {
                Data = data;
                Next = null!;
                Previous = null!;
            }
        }
        public int Count => count;
        public object? First { get { return head != null ? head.Data : null; } }
        public object? Last { get { return tail != null ? tail.Data : null; } }
        public SingleLinkedList()
        {
            head = null!;
            tail = null!;
            count = 0;
        }
        public void Add(object value)
        {
            Node newNode = new Node(value);
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
            Node newNode = new Node(value);

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

        public void Insert(int index, object value)
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
                Node newNode = new Node(value);
                Node current = head!;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next!;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                count++;
            }
        }

        public void Clear()
        {
            head = null!;
            tail = null!;
            count = 0;
        }

        public bool Contains(object value)
        {
            Node current = head!;
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

        public object[] ToArray()
        {
            object[] array = new object[count];
            Node current = head!;
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
