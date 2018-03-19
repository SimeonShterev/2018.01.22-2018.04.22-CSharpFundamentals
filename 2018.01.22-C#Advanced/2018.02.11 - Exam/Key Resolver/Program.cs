using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Key_Resolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            Stack<int> ammo = new Stack<int>();
            Queue<int> locks = new Queue<int>();
            FillQueueWithAmmo(ammo);
            FillStackWithLocks(locks);
            int award = int.Parse(Console.ReadLine());
            int bulletsCounter = 0;
            while(ammo.Any() && locks.Any())
            {
                bulletsCounter++;
                if(ammo.Peek()<=locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    ammo.Pop();
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    ammo.Pop();
                }
                if(bulletsCounter%gunBarrel==0 && ammo.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }
            if(!locks.Any())
            {
                int moneyEarned = award - bulletsCounter * bulletPrice;
                int bulletsLeft = ammo.Count();
                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                int locksLeft = locks.Count();
                Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
            }
            int debug = 0;
        }

        private static void FillStackWithLocks(Queue<int> locks)
        {
            int[] locksArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < locksArr.Length; i++)
            {
                locks.Enqueue(locksArr[i]);
            }
        }

        private static void FillQueueWithAmmo(Stack<int> ammo)
        {
            int[] ammoArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < ammoArr.Length; i++)
            {
                ammo.Push(ammoArr[i]);
            }
        }
    }
}
