using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] jagged = new int[3][];
            int firstCounter = 0;
            int secondCounter = 0;
            int thirdCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int remainder = Math.Abs(input[i]) % 3;
                if (remainder == 0)
                {
                    firstCounter++;
                }
                else if (remainder == 1)
                {
                    secondCounter++;
                }
                else
                {
                    thirdCounter++;
                }
            }
            jagged[0] = new int[firstCounter];
            jagged[1] = new int[secondCounter];
            jagged[2] = new int[thirdCounter];
            firstCounter = 0;
            secondCounter = 0;
            thirdCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int remainder = Math.Abs(input[i]) % 3;
                if (remainder == 0)
                {
                    jagged[0][firstCounter] = input[i];
                    firstCounter++;
                }
                else if (remainder == 1)
                {
                    jagged[1][secondCounter] = input[i];
                    secondCounter++;
                }
                else
                {
                    jagged[2][thirdCounter] = input[i];
                    thirdCounter++;
                }
            }
            foreach (var row in jagged)
                {
                    Console.WriteLine(string.Join(" ", row));
                }
            
        }
    }
}
