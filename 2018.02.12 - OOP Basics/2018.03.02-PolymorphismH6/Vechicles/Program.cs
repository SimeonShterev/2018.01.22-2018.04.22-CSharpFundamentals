using System;

class Program
{
    static void Main(string[] args)
    {
        Vechicle[] array = new Vechicle[3];
        for (int i = 0; i < 3; i++)
        {
            string[] input = ReadInput();
            string typeOfVechicle = input[0];
            switch (typeOfVechicle)
            {
                case "Car":
                    array[0] = (Car)CreateVehicle(input);
                    break;
                case "Truck":
                    array[1] = (Truck)CreateVehicle(input);
                    break;
                case "Bus":
                    array[2] = (Bus)CreateVehicle(input);
                    break;
            }
        }
        Car car = (Car)array[0];
        Truck truck = (Truck)array[1];
        Bus bus = (Bus)array[2];
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] commandArgs = Console.ReadLine().Split();
            string command = commandArgs[0];
            string vechicle = commandArgs[1];
            try
            {
                switch (command)
                {
                    case "Drive":
                        Drive(car, truck, bus, commandArgs, vechicle);
                        break;
                    case "DriveEmpty":
                        DriveEmpty(bus, commandArgs);
                        break;
                    case "Refuel":
                        Refuel(car, truck, bus, commandArgs, vechicle);
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        double carsFuelLeft = car.FuelQuantity;
        double trucksFuelLeft = truck.FuelQuantity;
        double busFuelLeft = bus.FuelQuantity;
        Console.WriteLine($"Car: {carsFuelLeft:f2}");
        Console.WriteLine($"Truck: {trucksFuelLeft:f2}");
        Console.WriteLine($"Bus: {busFuelLeft:f2}");
    }

    public static void Refuel(Car car, Truck truck, Bus bus, string[] commandArgs, string vechicle)
    {
        double fuel = double.Parse(commandArgs[2]);
        if (vechicle == "Car")
        {
            car.Refueling(fuel);
        }
        else if (vechicle == "Bus")
        {
            bus.Refueling(fuel);
        }
        else
        {
            truck.Refueling(fuel, true);
        }
    }

    private static void DriveEmpty(Bus bus, string[] commandArgs)
    {
        double distance = double.Parse(commandArgs[2]);
        string info = ((Bus)bus).DriveEmpty(distance);
        Console.WriteLine(info);
    }

    private static void Drive(Car car, Truck truck, Bus bus, string[] commandArgs, string vechicle)
    {
        double distance = double.Parse(commandArgs[2]);
        string info;
        if (vechicle == "Car")
        {
            info = car.Drive(distance);
        }
        else if (vechicle == "Bus")
        {
            info = bus.Drive(distance);
        }
        else
        {
            info = truck.Drive(distance);
        }
        Console.WriteLine(info);
    }

    private static Vechicle CreateVehicle(string[] vehicleInput)
    {
        var vehicleType = vehicleInput[0];

        var FuelQuantity = double.Parse(vehicleInput[1]);
        var FuelConsumption = double.Parse(vehicleInput[2]);
        var TankCapacity = double.Parse(vehicleInput[3]);

        Vechicle vehicle = null;

        switch (vehicleType)
        {
            case "Car": return vehicle = new Car(FuelQuantity, TankCapacity, FuelConsumption);
            case "Truck": return vehicle = new Truck(FuelQuantity, TankCapacity, FuelConsumption);
            case "Bus": return vehicle = new Bus(FuelQuantity, TankCapacity, FuelConsumption);
            default:
                return default(Vechicle);
        }

    }

    private static string[] ReadInput()
    {
        return Console.ReadLine().Split();
    }
}