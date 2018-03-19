using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 4, 3 };
            List<int> list = new List<int>() { 1, 2, 3 };
            arr.Reverse();
            list.Reverse();
            string a = "abc";
            char[] b = a.ToCharArray().Reverse().ToArray();
            Console.WriteLine(string.Join("", b));
            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
