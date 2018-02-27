using System;
using System.Collections.Generic;
using System.Text;

public class Pizza
{
    private List<Toppings> toppingList;
    private string name;
    private double caloriesCounter;

    public Pizza(string name)
    {
        this.Name = name;
        this.toppingList = new List<Toppings>();
    }
    public string Name
    {
        get { return this.name; }
        set
        {
            if(value.Length<1 || value.Length>15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public double CaloriesCounter
    {
        get { return this.caloriesCounter; }
        set { this.caloriesCounter += value; }
    }

    public int ToppingCount
    {
        get { return this.toppingList.Count; }
    }

    public void CheckToppingCount()
    {
        if (this.toppingList.Count > 10)
        {
            Console.WriteLine("Number of toppings should be in range [0..10].");
            Environment.Exit(0);
        }
    }

    public void AddTopping(Toppings topping)
    {
        this.toppingList.Add(topping);
    }
}