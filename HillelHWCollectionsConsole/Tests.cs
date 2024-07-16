using HillelHWCollectionsLibrary;
using HillelHWCollectionsLibrary.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsConsole
{
    public class Tests
    {
        public Tests() 
        {
            TestList();
            TestBTree();
            TestSingleLinkedList();
            TestDoubleLinkedList();
            TestQueue();
            TestStack();
        }
        public void TestList()
        {
            Console.WriteLine("Test List");
            OwnList<object> ownList = new OwnList<object>();
            ownList.Add(1);
            ownList.Add("asdasd");
            ownList.Add('s');
            ownList.Add(true);
            ownList.Add(1000);
            ownList.Add(12.8);
            object[] objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            Console.WriteLine($"Count: {ownList.Count}\nCheck 1000: {ownList.Contains(1000)}\nIndex of 's'{ownList.IndexOf('s')}");
            ownList.Reverse();
            ownList.Insert(3, "foo");
            ownList.Remove(12.8);
            ownList.RemoveAt(1);
            Console.WriteLine("Changes: Reverse+Insert 'foo' on index 3, remove 12.8, remove at index 1");
            objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            ownList.Clear();
            Console.WriteLine($"clear and count: {ownList.Count}");

        }
        public void TestBTree()
        {
            Console.WriteLine("\n\nTest Binary Tree");
            Console.WriteLine("Added 5,3,6,4,8,2");
            OwnTree<object> owntree = new OwnTree<object>();
            owntree.Add("3");
            owntree.Add(15.2);
            owntree.Add(true);
            owntree.Add('h');
            owntree.Add(new SingleLinkedList<object>());
            owntree.Add(4);
            object[] objs = owntree.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            
            owntree.Clear();
            objs = owntree.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
        }
        public void TestSingleLinkedList()
        {
            Console.WriteLine("\n\nTest single Linked List");
            SingleLinkedList<object> ownList = new SingleLinkedList<object>();
            ownList.Add(1);
            ownList.Add("asdasd");
            ownList.Add('s');
            ownList.Add(true);
            ownList.Add(1000);
            ownList.Add(12.8);
            object[] objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            Console.WriteLine($"Count: {ownList.Count}\nCheck 12.8: {ownList.Contains(12.8)}\nFirst object {ownList.First}\nLast object {ownList.Last}");
            ownList.Insert(3, "foo");
            ownList.AddFirst("first");
            Console.WriteLine("Changes: Insert 'foo' on index 3, add first 'first'");
            objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            ownList.Clear();
            Console.WriteLine($"clear and count: {ownList.Count}");
        }
        public void TestDoubleLinkedList()
        {
            Console.WriteLine("\n\nTest double Linked List");
            DoubleLinkedList<object> ownList = new DoubleLinkedList<object>();
            ownList.Add(1);
            ownList.Add("asdasd");
            ownList.Add('s');
            ownList.Add(true);
            ownList.Add(1000);
            ownList.Add(12.8);
            object[] objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            Console.WriteLine($"Count: {ownList.Count}\nCheck 12.8: {ownList.Contains(12.8)}\nFirst object {ownList.First}\nLast object {ownList.Last}");
            ownList.Insert(3, "foo");
            ownList.AddFirst("first");
            Console.WriteLine("Changes: Insert 'foo' on index 3, add first 'first'");
            objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            ownList.RemoveFirst();
            ownList.RemoveLast();
            ownList.Remove(1000);
            Console.WriteLine("Changes: Deleted first object, last, and 1000");
            objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            ownList.Clear();
            Console.WriteLine($"clear and count: {ownList.Count}");
        }
        public void TestQueue()
        {
            Console.WriteLine("\n\nQueue List");
            HillelHWCollectionsLibrary.Queue<object> ownList = new HillelHWCollectionsLibrary.Queue<object>();
            ownList.Enqueue(1);
            ownList.Enqueue("asdasd");
            ownList.Enqueue('s');
            ownList.Enqueue(true);
            ownList.Enqueue(1000);
            ownList.Enqueue(12.8);
            object[] objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            Console.WriteLine($"Count: {ownList.Count}\nCheck 12.8: {ownList.Contains(12.8)} Peek {ownList.Peek()}");
            ownList.Dequeue();
            ownList.Dequeue();
            Console.WriteLine("Changes: Twice dequeue");
            objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            ownList.Clear();
            Console.WriteLine($"clear and count: {ownList.Count}");
        }
        public void TestStack()
        {
            Console.WriteLine("\n\nStack List");
            HillelHWCollectionsLibrary.Stack<object> ownList = new HillelHWCollectionsLibrary.Stack<object>();
            ownList.Push(1);
            ownList.Push("asdasd");
            ownList.Push('s');
            ownList.Push(true);
            ownList.Push(1000);
            ownList.Push(12.8);
            object[] objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            Console.WriteLine($"Count: {ownList.Count}\nCheck 's': {ownList.Contains('s')} Peek {ownList.Peek()}");
            Console.WriteLine($"Pop {ownList.Pop()}");
            Console.WriteLine($"Pop {ownList.Pop()}");
            Console.WriteLine("Changes: Twice pop");
            objs = ownList.ToArray();
            foreach (object obj in objs) { Console.WriteLine(obj); }
            ownList.Clear();
            Console.WriteLine($"clear and count: {ownList.Count}");
        }
    }
}
