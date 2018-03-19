using System;
using System.Collections.Generic;
using System.Text;

public class Owl : Bird, ITryFeed
{
    private List<string> foodList = new List<string>()
    {
        "Meat"
    };

    public Owl(double wingSize, string name, double wieght, int foodEaten)
        : base(wingSize, name, wieght, foodEaten) { }

    public override void ProduceSound()
    {
        Console.WriteLine("Hoot Hoot");
    }

    public override void WeightIncrease(int foodQuantity)
    {
        this.Weight = this.Weight + (foodQuantity * 0.25);
    }

    public override bool TryFeed(string food)
    {
        if (!foodList.Contains(food))
        {
            Console.WriteLine($"{nameof(Owl)} does not eat {food}!");
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        string result = $"{nameof(Owl)} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        return result;
    }
}