using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private string name;
    private double price;

    public Product(string name, double money)
    {
        this.Name = name;
        this.Price = money;
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            price = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }
    //public override string ToString()
    //{
    //    return this.name;
    //}
}
