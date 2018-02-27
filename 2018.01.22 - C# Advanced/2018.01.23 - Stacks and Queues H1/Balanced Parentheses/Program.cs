using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
             char[] brackets = Console.ReadLine().ToCharArray();
             if(brackets.Length%2!=0 || brackets.Length == 0)
             {
                PrintNO();
             }
             char[] opening = new[] { '(', '[', '{' };
             char[] closing = new[] { ')', ']', '}' };
             Stack<int> stack = new Stack<int>();
             for (int i = 0; i < brackets.Length; i++)
             {
                 if (opening.Contains(brackets[i]))
                 {
                     int num = Array.IndexOf(opening, brackets[i]);
                     stack.Push(num);
                 }
                 else if (closing.Contains(brackets[i]) && stack.Peek() == Array.IndexOf(closing, brackets[i]))
                 {
                     stack.Pop();
                 }
                 else
                 {
                    PrintNO();
                 }
             }
             if (stack.Any())
             {
                PrintNO();
             }
             else
             {
                 Console.WriteLine("YES");
             }
        }
        static void PrintNO()
        {
            Console.WriteLine("NO");
            Environment.Exit(0);
        }
    }
}
