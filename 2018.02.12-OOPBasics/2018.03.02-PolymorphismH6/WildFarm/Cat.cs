using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Feline
{
    private List<string> foodList = new List<string>()
    {
        "Vegetable"
        ,"Meat"
    };

    public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
        : base(name, weight, foodEaten, livingRegion, breed) { }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }

    public override void WeightIncrease(int foodQuantity)
    {
        this.Weight = this.Weight + (foodQuantity * 0.3);
    }

    public override bool TryFeed(string food)
    {
        if (!foodList.Contains(food))
        {
            Console.WriteLine($"{nameof(Cat)} does not eat {food}!");
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        string result = $"{nameof(Cat)} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        return result;
    }
}