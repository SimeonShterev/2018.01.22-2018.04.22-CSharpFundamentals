using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private double money;
    private List<Product> bagOfProducts;

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new List<Product>();
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    public double Money
    {
        get { return this.money; }
        set
        {
            if(value<0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public List<Product> BagOfProduct
    {
        get { return this.bagOfProducts; }
    }

    public void TryBuyProduct(Product product, Person person)
    {
        if (person.money >= product.Price)
        {
            person.money -= product.Price;
            bagOfProducts.Add(product);
            Console.WriteLine($"{person.name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{person.name} can't afford {product.Name}");
        }
    }

    public override string ToString()
    {
        string productsPossessed = string.Join(", ", this.BagOfProduct.Select(p => p.Name));
        if(productsPossessed.Length==0)
        {
            productsPossessed = "Nothing bought";
        }
        return $"{this.name} - {productsPossessed}";
    }
}
