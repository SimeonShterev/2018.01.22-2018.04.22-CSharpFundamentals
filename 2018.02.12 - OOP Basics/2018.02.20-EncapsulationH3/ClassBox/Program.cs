using System;

class Program
{
    static void Main(string[] args)
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        Box box = new Box(length, width, height);

        double surfaceArea = box.SurfaceArea(length, width, height);
        double lateralArea = box.LateralArea(length, width, height);
        double volume = box.Volume(length, width, height);
        Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        Console.WriteLine($"Lateral Surface Area - {lateralArea:f2}");
        Console.WriteLine($"Volume - {volume:f2}");
    }
}
