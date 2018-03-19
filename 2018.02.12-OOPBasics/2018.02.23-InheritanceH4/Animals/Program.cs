using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animalList = new List<Animal>();
        string animalType;
        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            try
            {
                ParseAnimals(animalList, animalType);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        foreach (var animal in animalList)
        {
            Console.WriteLine(animal);
        }
    }

    private static void ParseAnimals(List<Animal> animalList, string animalType)
    {
        string[] inputData = Console.ReadLine().Split();
        string name = inputData[0];
        int age = int.Parse(inputData[1]);
        string gender = inputData[2];
        switch (animalType)
        {
            case "Cat":
                Cat cat = new Cat(name, age, gender);
                animalList.Add(cat);
                break;
            case "Dog":
                Dog dog = new Dog(name, age, gender);
                animalList.Add(dog);
                break;
            case "Frog":
                Frog frog = new Frog(name, age, gender);
                animalList.Add(frog);
                break;
            case "Kitten":
                Kitten kitten = new Kitten(name, age);
                animalList.Add(kitten);
                break;
            case "Tomcat":
                Tomcat tomcat = new Tomcat(name, age);
                animalList.Add(tomcat);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}
