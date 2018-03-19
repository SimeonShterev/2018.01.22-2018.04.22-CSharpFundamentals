using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Numbers_with_a_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            Stack<string> stack = new Stack<string>();
            foreach(var integer in input)
            {
                stack.Push(integer);
            }
            while(stack.Count!=0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
