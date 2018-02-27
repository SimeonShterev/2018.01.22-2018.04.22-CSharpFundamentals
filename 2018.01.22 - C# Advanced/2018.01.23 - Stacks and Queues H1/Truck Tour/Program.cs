using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Queue<int[]> fuelData = new Queue<int[]>();
            for (int i = 0; i < lines; i++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                fuelData.Enqueue(data);
            }
            int pumpToStart = 0;
            while (true)
            {
                long fuelContainer = 0;
                for (int j = 0; j < lines; j++)
                {
                    int[] fuelInfo = fuelData.Dequeue();
                    fuelData.Enqueue(fuelInfo);
                    fuelContainer = fuelContainer + fuelInfo[0] - fuelInfo[1];
                    pumpToStart++;
                    if (fuelContainer < 0)
                    {
                        break;
                    }
                }
                if (fuelContainer >= 0)
                {
                    int answer = pumpToStart - lines;
                    Console.WriteLine(answer);
                    break;
                }
            }

        }
    }
}
