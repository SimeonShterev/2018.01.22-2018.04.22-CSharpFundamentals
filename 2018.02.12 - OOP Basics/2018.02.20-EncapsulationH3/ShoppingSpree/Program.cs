using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Person> peopleList = new List<Person>();
        List<Product> productsList = new List<Product>();
        try
        {
            ParseNames(peopleList);
            ParseProducts(productsList);
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] commandArgs = command.Split();
            string personName = commandArgs[0];
            string productName = commandArgs[1];
            Product product = productsList.Find(p => p.Name == productName);
            Person person = peopleList.Find(p => p.Name == personName);
            person.TryBuyProduct(product, person);
        }
        foreach (var person in peopleList)
        {
            Console.WriteLine(person);
        }
    }

    private static void ParseProducts(List<Product> productsList)
    {
        string[] productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < productInput.Length; i++)
        {
            string[] tokens = productInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            double price = double.Parse(tokens[1]);
            var product = new Product(name, price);
            productsList.Add(product);
        }
    }

    private static void ParseNames(List<Person> peopleList)
    {
        string[] nameInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < nameInput.Length; i++)
        {
            string[] tokens = nameInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            double money = double.Parse(tokens[1]);
            var person = new Person(name, money);
            peopleList.Add(person);
        }
    }
}
