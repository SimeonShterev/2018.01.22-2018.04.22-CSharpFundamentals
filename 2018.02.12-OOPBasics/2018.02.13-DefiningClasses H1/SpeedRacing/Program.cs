using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Car> carList = new List<Car>();
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string[] data = Console.ReadLine().Split();
            string model = data[0];
            double fuel = double.Parse(data[1]);
            double consumption = double.Parse(data[2]);
            Car car = new Car(model, fuel, consumption);
            carList.Add(car);
        }
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] commandArgs = command.Split();
            string model = commandArgs[1];
            int distance = int.Parse(commandArgs[2]);
            Car car = carList.Find(c => c.Model == model);
            car.CarOperation(car, model, distance);

        }
        foreach (var car in carList)
        {
            string model = car.Model;
            double fuelLeft = car.Fuel;
            int distanceTraveled = car.Distance;
            Console.WriteLine($"{model} {fuelLeft:f2} {distanceTraveled}");
        }
    }
}
