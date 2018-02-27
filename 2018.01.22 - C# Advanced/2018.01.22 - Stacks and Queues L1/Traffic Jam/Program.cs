using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsToPass = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int numOfGreenLights = 0;
            while(true)
            {
                string input = Console.ReadLine();
                if(input=="end")
                {
                    break;
                }
                if(input=="green")
                {
                    numOfGreenLights += 1;
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            int carsToPassCapacity = carsToPass * numOfGreenLights;
            int passedCars = 0;
            for (int i = 1; i <= carsToPassCapacity; i++)
            {
                if (queue.Count == 0)
                {
                    break;
                }
                Console.WriteLine($"{queue.Dequeue()} passed!");
                passedCars++;
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
