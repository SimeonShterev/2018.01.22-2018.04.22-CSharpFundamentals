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
            double animalWeight = double.Parse(animalInput[2]);
            double wingSize = 0.0;
            string breed = null;
            string livingRegion = null;
            string[] foodInput = Console.ReadLine().Split();
            string foodType = foodInput[0];
            int foodQuantity = int.Parse(foodInput[1]);
            switch (animalType)
            {
                case "Owl":
                    wingSize = double.Parse(animalInput[3]);
                    Owl owl = new Owl(wingSize, animalName, animalWeight, 0);
                    owl.ProduceSound();
                    Feed(foodType, foodQuantity, owl);
                    AddToList(animals, owl);
                    break;
                case "Hen":
                    wingSize = double.Parse(animalInput[3]);
                    Hen hen = new Hen(wingSize, animalName, animalWeight, 0);
                    hen.ProduceSound();
                    Feed(foodType, foodQuantity, hen);
                    AddToList(animals, hen);
                    break;
                case "Mouse":
                    livingRegion = animalInput[3];
                    Mouse mouse = new Mouse(animalName, animalWeight, 0, livingRegion);
                    mouse.ProduceSound();
                    Feed(foodType, foodQuantity, mouse);
                    AddToList(animals, mouse);
                    break;
                case "Dog":
                    livingRegion = animalInput[3];
                    Dog dog = new Dog(animalName, animalWeight, 0, livingRegion);
                    dog.ProduceSound();
                    Feed(foodType, foodQuantity, dog);
                    AddToList(animals, dog);
                    break;
                case "Cat":
                    livingRegion = animalInput[3];
                    breed = animalInput[4];
                    Cat cat = new Cat(animalName, animalWeight, 0, livingRegion, breed);
                    cat.ProduceSound();
                    Feed(foodType, foodQuantity, cat);
                    AddToList(animals, cat);
                    break;
                case "Tiger":
                    livingRegion = animalInput[3];
                    breed = animalInput[4];
                    Tiger tiger = new Tiger(animalName, animalWeight, 0, livingRegion, breed);
                    tiger.ProduceSound();
                    Feed(foodType, foodQuantity, tiger);
                    AddToList(animals, tiger);
                    break;
            }
        }
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void AddToList(List<Animal> animals, Animal owl)
    {
        animals.Add(owl);
    }

    private static void Feed(string foodType, int foodQuantity, Animal mouse)
    {
        bool doesEat = mouse.TryFeed(foodType);
        if (doesEat)
        {
            mouse.WeightIncrease(foodQuantity);
            mouse.FoodEaten = foodQuantity;
        }
    }
}