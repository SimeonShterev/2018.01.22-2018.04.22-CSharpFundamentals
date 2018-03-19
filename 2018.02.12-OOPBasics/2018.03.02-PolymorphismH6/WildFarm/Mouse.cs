using System;
using System.Collections.Generic;
using System.Text;

public class Mouse : Mammal
{
    private List<string> foodList = new List<string>()
    {
        "Vegetable"
        ,"Fruit"
    };

    public Mouse(string name, double weight, int foodEaten, string livingRegion)
        : base(name, weight, foodEaten, livingRegion) { }

    public override void ProduceSound()
    {
        Console.WriteLine("Squeak");
    }

    public override void WeightIncrease(int foodQuantity)
    {
        this.Weight = this.Weight + (foodQuantity * 0.1);
    }

    public override bool TryFeed(string food)
    {
        if (!foodList.Contains(food))
        {
            Console.WriteLine($"{nameof(Mouse)} does not eat {food}!");
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        string result = $"{nameof(Mouse)} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        return result;
    }
}