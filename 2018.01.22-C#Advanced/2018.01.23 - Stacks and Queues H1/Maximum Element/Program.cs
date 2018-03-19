using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Stack<int> biggestNum = new Stack<int>();
            for (int i = 0; i < N; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (input.Length == 2)
                {
                    stack.Push(input[1]);
                    if(biggestNum.Count==0)
                    {
                        biggestNum.Push(input[1]);
                    }
                    else if(biggestNum.Peek()<input[1])
                    {
                        biggestNum.Push(input[1]);
                    }
                }
                else if(input[0]==2)
                {
                    if (biggestNum.Peek() == stack.Peek())
                    {
                        biggestNum.Pop();
                    }
                    stack.Pop();
                }
                else if(input[0]==3)
                {
                    Console.WriteLine(biggestNum.Peek());
                }
            }
        }
    }
}
