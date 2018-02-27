using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Rectangle> rectangleList = new List<Rectangle>();
        var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int lines = tokens[0];
        int intersNum = tokens[1];
        for (int i = 0; i < lines; i++)
        {
            ParseRectangles(rectangleList);
        }
        for (int i = 0; i < intersNum; i++)
        {
            bool result = CheckIntersection(rectangleList);
            Console.WriteLine(result);
        }
    }

    private static bool CheckIntersection(List<Rectangle> rectangleList)
    {
        string[] command = Console.ReadLine().Split();
        Rectangle firstRect = rectangleList.Find(r => r.Id == command[0]);
        Rectangle secondRect = rectangleList.Find(r => r.Id == command[1]);
        bool result = firstRect.CheckIntersection(secondRect);
        return result;
    }

    private static void ParseRectangles(List<Rectangle> rectangleList)
    {
        string[] input = Console.ReadLine().Split();
        string id = input[0];
        int width = int.Parse(input[1]);
        int height = int.Parse(input[2]);
        int[] topLeftCoords = new int[] { int.Parse(input[3]), int.Parse(input[4]) };
        Rectangle rectangle = new Rectangle(id, width, height, topLeftCoords);
        rectangleList.Add(rectangle);
    }
}