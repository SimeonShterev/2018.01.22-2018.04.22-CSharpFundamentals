using System;

class Program
{
    static void Main(string[] args)
    {
        string pizzaName = Console.ReadLine().Split()[1];
        CheckPizzaName(pizzaName);
        Pizza pizza = new Pizza(pizzaName);
        try
        {
            Dough dough = ParseDough(pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                ParseTopping(pizza, command);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
        Console.WriteLine($"{pizzaName} - {pizza.CaloriesCounter:f2} Calories.");
    }

    private static void CheckPizzaName(string pizzaName)
    {
        if (pizzaName.Length < 1 || pizzaName.Length > 15)
        {
            Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
            Environment.Exit(0);
        }
    }

    private static void ParseTopping(Pizza pizza, string command)
    {
        string[] toppingInput = command.Split();
        string toppingType = toppingInput[1];
        double toppingWeight = double.Parse(toppingInput[2]);
        Toppings topping = new Toppings(toppingWeight, toppingType);
        double toppingTypeModifier = topping.ToppingType(toppingType);
        double toppingCals = 2 * toppingWeight * toppingTypeModifier;
        pizza.AddTopping(topping);
        pizza.CheckToppingCount();
        pizza.CaloriesCounter = toppingCals;
        //Console.WriteLine(toppingCals);
    }

    private static Dough ParseDough(Pizza pizza)
    {
        string[] doughInput = Console.ReadLine().Split();
        string flourType = doughInput[1].ToLower();
        string bakingTech = doughInput[2].ToLower();
        double weight = double.Parse(doughInput[3]);
        Dough dough = new Dough(weight);
        double bakingTechModifier = dough.BakingTechnique(bakingTech);
        double flourTypeModifier = dough.FlourType(flourType);
        double doughCals = 2 * dough.Weight * flourTypeModifier * bakingTechModifier;
        pizza.CaloriesCounter = doughCals;
        //Console.WriteLine(doughCals);
        return dough;
    }
}
