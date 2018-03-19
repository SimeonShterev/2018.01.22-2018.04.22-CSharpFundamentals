using System;

class Program
{
    static void Main(string[] args)
    {
        string personName = Console.ReadLine();
        Ferrari ferrari = new Ferrari(personName);
        Console.WriteLine(ferrari);
    }
}