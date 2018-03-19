using System;

class Program
{
    static void Main(string[] args)
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        try
        {
            Box box = new Box(length, width, height);
            //double surfaceArea = box.SurfaceArea();
            //double lateralArea = box.LateralArea();
            //double volume = box.Volume();
            //Console.WriteLine($"Surface Area - {surfaceArea:f2}");
            //Console.WriteLine($"Lateral Surface Area - {lateralArea:f2}");
            //Console.WriteLine($"Volume - {volume:f2}");
            Console.WriteLine(box);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }


        
    }
}
