using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        List<Car> allCars = new List<Car>();
        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split();
            ParseCars(input, allCars);
        }
        string command = Console.ReadLine();
        if(command=="fragile")
        {
            foreach (var car in allCars.FindAll(cars=>cars.Cargo.Type=="fragile"))
            {
                int lowerPressure = car.TiresCount;
                if(lowerPressure!=0)
                    Console.WriteLine(car.Model);
            }
        }
        else
        {
            foreach (var car in allCars.FindAll(cars => cars.Cargo.Type == "flamable"))
            {
                int highPower = car.Engine.Power;
                if (highPower >250)
                    Console.WriteLine(car.Model);
            }
        }
    }

    private static void ParseCars(string[] input, List<Car> allCars)
    {
        string model = input[0];
        int enginePower = int.Parse(input[2]);
        Engine engine = new Engine(enginePower);
        string cargoType = input[4];
        Cargo cargo = new Cargo(cargoType);
        double tire1Pressure = double.Parse(input[5]);
        double tire2Pressure = double.Parse(input[7]);
        double tire3Pressure = double.Parse(input[9]);
        double tire4Pressure = double.Parse(input[11]);
        double[] allTires = new double[] { tire1Pressure, tire2Pressure, tire3Pressure, tire4Pressure };
        List<Tire> tireList = new List<Tire>();
        for (int i = 0; i < allTires.Length; i++)
        {
            Tire tire = new Tire(allTires[i]);
            tire.AddTire(tireList, tire);
        }
        Car car = new Car(cargo, tireList, model, engine);
        allCars.Add(car);
    }
}
