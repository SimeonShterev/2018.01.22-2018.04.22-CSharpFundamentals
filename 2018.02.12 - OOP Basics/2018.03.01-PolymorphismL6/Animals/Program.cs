﻿using System;

class Program
{
    static void Main(string[] args)
    {
        Animal cat = new Cat("Pesho","Whiskas");
        Animal dog = new Dog("Gosho","Meat");

        Console.WriteLine(cat.MakeSound());
        Console.WriteLine(dog.MakeSound());
    }
}