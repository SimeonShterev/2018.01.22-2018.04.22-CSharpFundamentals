using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Mammal
{
    private List<string> foodList = new List<string>()
    {
        "Meat"
    };

    public Dog(string name, double weight, int foodEaten, string livingRegion)
        : base(name, weight, foodEaten, livingRegion) { }

    public override void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }

    public override void WeightIncrease(int foodQuantity)
    {
        this.Weight = this.Weight + (foodQuantity * 0.4);
    }

    public override bool TryFeed(string food)
    {
        if (!foodList.Contains(food))
        {
            Console.WriteLine($"{nameof(Dog)} does not eat {food}!");
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        string result = $"{nameof(Dog)} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        return result;
    }
}