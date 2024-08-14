using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.LinqTasksHW
{
    public static class LinqTasks
    {
        public static void Task1()
        {
            Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41)));
        }
        public static void Task2()
        {
            Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41).Filter(n => n % 3 == 0)));
        }
        public static void Task3()
        {
            Console.WriteLine(string.Join(" ", Enumerable.Repeat("Linq", 10)));
        }
        public static void Task4()
        {
            Console.WriteLine(string.Join(" ", "aaa;abb;ccc;dap".Split(';').Where(w => w.Contains('a'))));
        }
        public static void Task5()
        {
            Console.WriteLine(string.Join(",", "aaa;abb;ccc;dap".Split(';').Where(w => w.Contains('a')).Select(word => word.Count(ch => ch == 'a'))));
        }
        public static void Task6()
        {
            Console.WriteLine(new string("aaa;xabbx;abb;ccc;dap").Split(';').Contains("abb"));
        }
        public static void Task7()
        {
            Console.WriteLine(new string("aaa;xabbx;abb;ccc;dap").Split(';').MaxBy(word => word.Length));
        }
        public static void Task8()
        {
            Console.WriteLine(new string("aaa;xabbx;abb;ccc;dap").Split(';').Average(word => word.Length));
        }
        public static void Task9()
        {
            Console.WriteLine(new string("aaa;xabbx;abb;ccc;dap;zh").Split(';').MinBy(word => word.Length)!.Reverse().ToArray());
        }
        public static void Task10()
        {
            Console.WriteLine(new string("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh").Split(';').FirstOrDefault(word => word.StartsWith("aa")).Skip(2).All(ch => ch == 'b'));
        }
        public static void Task11()
        {
            Console.WriteLine(new string("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh").Split(';').Skip(2).LastOrDefault(word => word.EndsWith("bb")));
        }

    }

}
