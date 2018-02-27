using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] firstDateArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int firstYear = firstDateArr[0];
        int firstMonth = firstDateArr[1];
        int firstDay = firstDateArr[2];
        DateTime firstDate = new DateTime(firstYear, firstMonth, firstDay);
        int[] secondDateArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int secondYear = secondDateArr[0];
        int secondMonth = secondDateArr[1];
        int secondDay = secondDateArr[2];
        DateTime secondDate = new DateTime(secondYear, secondMonth, secondDay);
        double difference = Math.Abs((firstDate - secondDate).TotalDays);
        Console.WriteLine(difference);
    }
}
