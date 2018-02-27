using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> addFunc = num => num + 1;
            Func<int, int> multiplyFunc = num => num * 2;
            Func<int, int> subtractFunc = num => num - 1;
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", input));
                }
                else
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        switch (command)
                        {
                            case "add":
                                input[i] = addFunc(input[i]);
                                break;
                            case "multiply":
                                input[i] = multiplyFunc(input[i]);
                                break;
                            case "subtract":
                                input[i] = subtractFunc(input[i]);
                                break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
