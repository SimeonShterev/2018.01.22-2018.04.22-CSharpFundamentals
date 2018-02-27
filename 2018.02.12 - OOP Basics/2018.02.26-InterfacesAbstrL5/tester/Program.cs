using System;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat("grey", 3);
            Animal dog = new Dog("blue", 20);
            Console.WriteLine(cat);
            Console.WriteLine(dog);
        }
    }
}
