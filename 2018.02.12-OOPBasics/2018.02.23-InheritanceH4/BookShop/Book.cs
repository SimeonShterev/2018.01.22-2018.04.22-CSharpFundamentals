using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private double price;

    public Book(string author, string title, double price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    {
        get { return this.author; }
        set
        {
            string[] authorNames = value.Split();
            if (authorNames.Length == 2 && char.IsDigit(authorNames[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public double Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Price not valid!");
            this.price = value;
        }
    }

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
                throw new ArgumentException("Title not valid!");
            this.title = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;

    }
}