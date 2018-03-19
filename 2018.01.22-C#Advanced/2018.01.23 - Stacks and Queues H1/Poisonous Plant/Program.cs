using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poisonous_Plant
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            string[] input = Console.ReadLine().Split();
            for (int i = N - 1; i >= 0; i--)
            {
                queue.Enqueue(int.Parse(input[i]));
            }
            ushort days = 0;
            while (true)
            {
                int loops = queue.Count;
                for (int i = 1; i < loops; i++)
                {
                    int rightPlant = queue.Dequeue();
                    if (queue.Peek() >= rightPlant)
                    {
                        queue.Enqueue(rightPlant);
                    }
                }
                queue.Enqueue(queue.Dequeue());
                if (queue.Count == loops)
                {
                    break;
                }
                days++;
            }
            Console.WriteLine(days);
        }
    }
}
