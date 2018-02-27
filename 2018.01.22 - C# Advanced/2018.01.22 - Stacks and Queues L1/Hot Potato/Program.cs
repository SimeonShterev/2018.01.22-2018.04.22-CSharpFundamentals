using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int positionToRemove = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(input);
            while(queue.Count>1)
            {
                for(int i=0;i<positionToRemove-1;i++)
                {
                    string personToGoLast = queue.Dequeue();
                    queue.Enqueue(personToGoLast);
                }
                string personToLeave = queue.Dequeue();
                Console.WriteLine($"Removed {personToLeave}");
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
