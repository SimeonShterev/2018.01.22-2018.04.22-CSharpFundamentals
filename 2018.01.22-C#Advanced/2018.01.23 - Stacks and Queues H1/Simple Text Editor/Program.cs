using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Stack<char> stack = new Stack<char>();
            Stack<char> allDelElem = new Stack<char>();
            Stack<string> allCommands = new Stack<string>();
            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                allCommands.Push(command[0]);
                if (command[0] != "4")
                    allCommands.Push(command[1]);
                switch (command[0])
                {
                    case "1":
                        char[] ch = command[1].ToCharArray();
                        AppendText(ch, stack);
                        break;
                    case "2":
                        int count = int.Parse(command[1]);
                        EraseElements(count, stack, allDelElem);
                        break;
                    case "3":
                        int index = int.Parse(command[1]);
                        char[] currentSymbols = new char[stack.Count];
                        for (int j = stack.Count - 1; j >= 0; j--)
                        {
                            char symbol = stack.Pop();
                            currentSymbols[j] = symbol;
                        }
                        for (int k = 0; k < currentSymbols.Length; k++)
                        {
                            stack.Push(currentSymbols[k]);
                        }
                        Console.WriteLine(ElementAtIndex(index, currentSymbols));
                        break;
                    case "4":
                        allCommands.Pop();
                        Undo(stack, allCommands, allDelElem);
                        break;
                }
            }
        }

        private static void Undo(Stack<char> stack, Stack<string> allCommands, Stack<char> allDelElem)                      // 4
        {
            string elemCount = allCommands.Pop();
            int command = int.Parse(allCommands.Pop());
            while(!(command!=1 ^ command!=2))
            {
                elemCount = allCommands.Pop();
                command = int.Parse(allCommands.Pop());
            }
            if (command == 1)   
            {
                int popCount = elemCount.Length;
                for (int i = 0; i < popCount; i++)
                {
                    stack.Pop();
                }
            }
            else
            {
                int charsToBringBack = int.Parse(elemCount);
                for (int i = 0; i < charsToBringBack; i++)
                {
                    stack.Push(allDelElem.Pop());
                }
            }
        }

        private static char ElementAtIndex(int index, char[] currentSymbols)                                                 // 3
        {
            return currentSymbols[index - 1];
        }

        private static void EraseElements(int count, Stack<char> stack, Stack<char> allDelElem)                              // 2
        {
            for (int i = 0; i < count; i++)
            {
                allDelElem.Push(stack.Pop());
            }
        }

        private static void AppendText(char[] ch, Stack<char> stack)                                                         // 1
        {
            for (int i = 0; i < ch.Length; i++)
            {
                stack.Push(ch[i]);
            }
        }
    }
}
