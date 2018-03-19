using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            long currentFib = 0;
            Stack<long> stack = new Stack<long>();
            stack.Push(1);
            stack.Push(1);
            for (int i = 1; i < N-1; i++)
            {
                long previous = stack.Pop();
                long prePrevious = stack.Peek();
                currentFib = previous + prePrevious;
                stack.Push(previous);
                stack.Push(currentFib);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}