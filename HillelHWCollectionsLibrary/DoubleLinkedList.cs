using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary
{
    public class DoubleLinkedList : SingleLinkedList
    {
        public new void Insert(int index, object value)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException();

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

                for (int i = 0; i < index; i++)
                {
                    current = current.Next!;
                }

                newNode.Next = current;
                newNode.Previous = current.Previous;
                if (current.Previous != null)
                {
                    current.Previous.Next = newNode;
                }
                current.Previous = newNode;

                if (index == 0)
                {
                    head = newNode;
                }

                count++;
            }
        }
        public DoubleLinkedList()
        {
            head = null!;
            tail = null!;
            count = 0;
        }

        public new void Add(object data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            count++;
        }

        public new void AddFirst(object data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            count++;
        }

        public void Remove(object data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous!;
                    }
                    else
                    {
                        tail = current.Previous!;
                    }

                    count--;
                    return;
                }
                current = current.Next;
            }
        }

        public void RemoveFirst()
        {
            if (head != null)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Previous = null!;
                }
                else
                {
                    tail = null!;
                }
                count--;
            }
        }

        public void RemoveLast()
        {
            if (tail != null)
            {
                tail = tail.Previous;
                if (tail != null)
                {
                    tail.Next = null!;
                }
                else
                {
                    head = null!;
                }
                count--;
            }
        }

        public new bool Contains(object data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
}
