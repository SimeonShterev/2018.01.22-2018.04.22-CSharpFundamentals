using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            Queue<long> queueFirstNums = new Queue<long>();
            queue.Enqueue(N);
            while ((queue.Count + queueFirstNums.Count) <= 50)
            {
                long firstInTheQueue = queue.Peek();
                long first = firstInTheQueue + 1;
                long second = firstInTheQueue * 2 + 1;
                long third = firstInTheQueue + 2;
                queue.Enqueue(first);
                queue.Enqueue(second);
                queue.Enqueue(third);
                queueFirstNums.Enqueue(queue.Dequeue());
            }
            while (queueFirstNums.Count != 0)
            {
                Console.Write(queueFirstNums.Dequeue() + " ");
            }
            while (queue.Count != 2)
            {
                Console.Write(queue.Dequeue() + " ");
            }
        }
    }
}
