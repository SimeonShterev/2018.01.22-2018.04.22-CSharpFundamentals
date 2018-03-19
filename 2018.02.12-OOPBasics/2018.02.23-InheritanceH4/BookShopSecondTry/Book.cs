using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public string Author
    {
        get { return this.author; }
        set
        {
            if (value.Split().Length==2 && char.IsDigit(value.Split()[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.title}")
            .AppendLine($"Author: {this.author}")
            .Append($"Price: {this.price:f2}");
        return result.ToString();
    }
}
