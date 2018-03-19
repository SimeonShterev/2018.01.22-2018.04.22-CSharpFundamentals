using System;
using System.Collections.Generic;
using System.Text;

public class Tiger : Feline
{
    private List<string> foodList = new List<string>()
    {
        "Meat"
    };

    public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
        : base(name, weight, foodEaten, livingRegion, breed) { }

    public override void ProduceSound()
    {
        Console.WriteLine("ROAR!!!");
    }

    public override void WeightIncrease(int foodQuantity)
    {
        this.Weight = this.Weight + (foodQuantity * 1);
    }

    public override bool TryFeed(string food)
    {
        if (!foodList.Contains(food))
        {
            Console.WriteLine($"{nameof(Tiger)} does not eat {food}!");
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        string result = $"{nameof(Tiger)} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        return result;
    }
}