using System;
using System.Collections.Generic;
using System.Text;

public class Hen :Bird , ITryFeed
{
    private List<string> foodList = new List<string>()
    {
        "Vegetable"
        ,"Fruit"
        ,"Meat"
        ,"Seeds"
    };

    public Hen(double wingSize, string name, double wieght, int foodEaten) 
        : base(wingSize, name, wieght, foodEaten) { }


    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }

    public override bool TryFeed(string food)
    {
        if(!foodList.Contains(food))
        {
            Console.WriteLine($"{nameof(Hen)} does not eat {food}!");
            return false;
        }
        return true;
    }

    public override void WeightIncrease(int foodQuantity)
    {
        this.Weight = this.Weight + (foodQuantity * 0.35);
    }

    public override string ToString()
    {
        string result = $"{nameof(Hen)} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        return result;
    }
}