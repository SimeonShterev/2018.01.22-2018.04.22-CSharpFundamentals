using System;


class Program
{
    static void Main(string[] args)
    {
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(3,4);

        Console.WriteLine($"Rectangle area: {rectangle.CalculateArea():f2}");
        Console.WriteLine($"Rectangle perimeter: {rectangle.CalculatePerimeter():f2}");
        Console.WriteLine($"Circle area: {circle.CalculateArea():f2}");
        Console.WriteLine($"Circle perimeter: {circle.CalculatePerimeter():f2}");

        Console.WriteLine(rectangle.Draw());
    }
}