using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        string command = null;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] animalInput = command.Split();
            string animalType = animalInput[0];
            string animalName = animalInput[1];
            double animalWieght = double.Parse(animalInput[2]);
            string[] foodInput = Console.ReadLine().Split();
            string foodType = foodInput[0];
            int foodQuantity = int.Parse(foodInput[1]);
            switch (animalType)
            {
                case "Owl":
                    double wingSize = double.Parse(animalInput[3]);
                    break;
                case "Hen":
                    wingSize = double.Parse(animalInput[3]);
                    break;
                case "Mouse":
                    string livingRegion = animalInput[3];
                    break;
                case "Dog":
                    livingRegion = animalInput[3];
                    break;
                case "Cat":
                    livingRegion = animalInput[3];
                    string breed = animalInput[4];
                    break;
                case "Tiger":
                    livingRegion = animalInput[3];
                    breed = animalInput[4];
                    break;
            }
        }
    }
}