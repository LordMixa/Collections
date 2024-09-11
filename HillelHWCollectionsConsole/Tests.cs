using HillelHWCollectionsLibrary.Collections;
using HillelHWCollectionsLibrary.Collections.BinaryTree;
using HillelHWCollectionsLibrary.LinqTasksHW;
using HillelHWCollectionsLibrary.Observer;
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
            //LinqHW1Test();
            LinqHW2Test();
            //IteratorTest();
            //TestObsList();
            //TestList();
            //TestBTree();
            //TestSingleLinkedList();
            //TestDoubleLinkedList();
            //TestQueue();
            //TestStack();
        }
        public void LinqHW1Test()
        {
            LinqTasks.Task1();
            LinqTasks.Task2();
            LinqTasks.Task3();
            LinqTasks.Task4();
            LinqTasks.Task5();
            LinqTasks.Task6();
            LinqTasks.Task7();
            LinqTasks.Task8();
            LinqTasks.Task9();
            LinqTasks.Task10();
            LinqTasks.Task11();
        }
        public void LinqHW2Test()
        {
            var tests = new LinqTasks2();
            tests.CompleteTasks();
        }
        public void IteratorTest()
        {
            var list = new OwnList<int>
            {
                1, 1, 1, 34, 65, 754, 88, 1, 2, 4
            };
            var coll = LinqExtensions.Filter(list, item => item >= 3);
            Console.WriteLine("Test Filter:\nMust be: 34, 65, 754, 88, 4");
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
            coll = LinqExtensions.Skip(list, 2);
            Console.WriteLine("\nTest Skip:\nMust be: 1, 34, 65, 754, 88, 1, 2, 4");
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
            coll = LinqExtensions.SkipWhile(list, item => item < 64);
            Console.WriteLine("\nTest SkipWhile:\nMust be: 65, 754, 88, 1, 2, 4");
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
            coll = LinqExtensions.Take(list, 4);
            Console.WriteLine("\nTest TakeWhile:\nMust be: 1, 1, 1, 34");
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
            coll = LinqExtensions.TakeWhile(list, item => item < 3);
            Console.WriteLine("\nTest TakeWhile:\nMust be: 1, 1, 1");
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
            var collint = LinqExtensions.First(list, item => item > 3 );
            Console.WriteLine("\nTest First:\nMust be: 34");
            Console.WriteLine(collint);
            collint = LinqExtensions.FirstOrDefault(list, item => item < 1);
            Console.WriteLine("\nTest FirstOrDefault:\nMust be: 0");
            Console.WriteLine(collint);
            collint = LinqExtensions.Last(list, item => item > 34);
            Console.WriteLine("\nTest Last:\nMust be: 88");
            Console.WriteLine(collint);
            collint = LinqExtensions.LastOrDefault(list, item => item < 3);
            Console.WriteLine("\nTest LastOrDefault:\nMust be: 2");
            Console.WriteLine(collint);
            coll = LinqExtensions.SelectMany(list, n => new List<int> { n * n, n * 10 });
            Console.WriteLine("\nTest SelectMany:\nMust be:  1, 10, 1, 10, 1, 10, 1156, 340, 4225, 650, 568516, 7540, 7744, 880, 1, 10, 4, 20, 16, 40");
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
            coll = LinqExtensions.Select(list, n => n*2);
            Console.WriteLine("\nTest Select:\nMust be:  2, 2, 2, 68, 130, 1508, 176, 2, 4, 8");
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
            var collbool = LinqExtensions.Any(list, item => item == 6);
            Console.WriteLine("\nTest Any predicate:\nMust be: False");
            Console.WriteLine(collbool);
            collbool = LinqExtensions.Any(list);
            Console.WriteLine("\nTest Any:\nMust be: True");
            Console.WriteLine(collbool);
            collbool = LinqExtensions.All(list, item => item > 0);
            Console.WriteLine("\nTest All:\nMust be: True");
            Console.WriteLine(collbool);
            var colls = LinqExtensions.ToArrayLinq(list);
            Console.WriteLine("\nTest ToArray:\nMust be: 1, 1, 1, 34, 65, 754, 88, 1, 2, 4");
            foreach (var item in colls)
            {
                Console.WriteLine(item);
            }
            coll = LinqExtensions.ToListLinq(list);
            Console.WriteLine("\nTest ToList:\nMust be: 1, 1, 1, 34, 65, 754, 88, 1, 2, 4");
            foreach (var item in colls)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nTest Enumerable Collections\nMust be: 2, 5, 7, 10, 11, 23, 53");
            var tree = new OwnTree<int> { 10, 2, 23, 7, 53, 11, 5 };
            var iterator = tree.GetEnumerator();

            Console.WriteLine("\nTest Tree");
            while (iterator.MoveNext())
                Console.Write(iterator.Current + " ");
            iterator.Dispose();

            var ownlist = new OwnList<int> { 10, 2, 23, 7, 53, 11, 5 };
            iterator = ownlist.GetEnumerator();
            Console.WriteLine("\n\nMust be: 10, 2, 23, 7, 53, 11, 5");
            Console.WriteLine("Test List");
            while (iterator.MoveNext())
                Console.Write(iterator.Current + " ");
            iterator.Dispose();

            var singlelist = new SingleLinkedList<int> { 10, 2, 23, 7, 53, 11, 5 };
            iterator = singlelist.GetEnumerator();

            Console.WriteLine("\nTest SingleLinkedList");
            while (iterator.MoveNext())
                Console.Write(iterator.Current + " ");
            iterator.Dispose();

            var doublelist = new DoubleLinkedList<int> { 10, 2, 23, 7, 53, 11, 5 };
            iterator = doublelist.GetEnumerator();

            Console.WriteLine("\nTest DoubleLinkedList");
            while (iterator.MoveNext())
                Console.Write(iterator.Current + " ");
            iterator.Dispose();

            var stack = new HillelHWCollectionsLibrary.Collections.Stack<int>();
            stack.Push(10);
            stack.Push(2);
            stack.Push(23);
            stack.Push(7);
            stack.Push(53);
            stack.Push(11);
            stack.Push(5);
            iterator = stack.GetEnumerator();

            Console.WriteLine("\nTest Stack");
            while (iterator.MoveNext())
                Console.Write(iterator.Current + " ");
            iterator.Dispose();

            var queue = new HillelHWCollectionsLibrary.Collections.Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(2);
            queue.Enqueue(23);
            queue.Enqueue(7);
            queue.Enqueue(53);
            queue.Enqueue(11);
            queue.Enqueue(5);
            iterator = queue.GetEnumerator();

            Console.WriteLine("\nTest Queue");
            while (iterator.MoveNext())
                Console.Write(iterator.Current + " ");
            iterator.Dispose();
        }

        public void TestObsList()
        {
            ObsList<string> obsList = new ObsList<string>();
            obsList.Add("123");
            obsList.Add("223");
            obsList.Add("323");
            obsList.Add("423");
            obsList.Add("523");
            obsList.Add("623");
            obsList.RemoveAt(0);
            obsList.RemoveAt(1);
            obsList.Remove("623");//тут буде виводитися на консоль ще одна RemoveAt 3, бо цей метод Remove викликає RemoveAt 
            obsList.Insert(2, "2");
            string[] strings = { "223", "423", "2", "523" };
            Console.WriteLine(strings.SequenceEqual(obsList.ToArray())); 
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
            Console.WriteLine("\n\nTest Binary Tree(Strung)");
            Console.WriteLine("Added strings: adasd, zc,  123, hillel, C#, code h, michael V");
            OwnTree<string> owntree = new OwnTree<string>();
            owntree.Add("adasd");
            owntree.Add("zc");
            owntree.Add("123");
            owntree.Add("hillel");
            owntree.Add("C#");
            owntree.Add("code");
            owntree.Add("michael V");
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
            HillelHWCollectionsLibrary.Collections.Queue<object> ownList = new HillelHWCollectionsLibrary.Collections.Queue<object>();
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
            HillelHWCollectionsLibrary.Collections.Stack<object> ownList = new HillelHWCollectionsLibrary.Collections.Stack<object>();
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
