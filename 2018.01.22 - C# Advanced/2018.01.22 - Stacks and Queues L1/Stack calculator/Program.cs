using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>();
            for(int i=input.Length-1;i>=0;i--)
            {
                stack.Push(input[i]);
            }
            int sum = 0;
            string operatorr = string.Empty;
            int operand = 0;
            while (stack.Count != 0)
            {
                if(stack.Peek()=="+" || stack.Peek()=="-")
                {
                    operatorr = stack.Pop();
                }
                else
                {
                    operand = int.Parse(stack.Pop());
                    if(operatorr=="+" || operatorr==string.Empty)
                    {
                        sum += operand;
                    }
                    else
                    {
                        sum -= operand;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
