using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Action<string> print = x => Console.WriteLine(x);
            for (int i = 0; i < input.Length; i++)
            {
                print(input[i]);
            }
        }
    }
}
