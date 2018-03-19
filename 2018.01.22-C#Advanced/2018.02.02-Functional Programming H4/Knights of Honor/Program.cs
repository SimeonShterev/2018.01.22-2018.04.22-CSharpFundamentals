using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Action<string> printer = x => Console.WriteLine("Sir " + x);
            for (int i = 0; i < input.Length; i++)
            {
                printer(input[i]);
            }
        }
    }
}
