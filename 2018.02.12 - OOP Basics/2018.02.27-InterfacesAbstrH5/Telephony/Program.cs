using System;

class Program
{
    static void Main(string[] args)
    {
        Phone phone = new Phone();
        string[] numbersInput = Console.ReadLine().Split();
        for (int i = 0; i < numbersInput.Length; i++)
        {
            phone.CheckNumber(numbersInput[i]);
        }
        string[] siteInput = Console.ReadLine().Split();
        for (int i = 0; i < siteInput.Length; i++)
        {
            phone.CheckSite(siteInput[i]);
        }
        Console.WriteLine(phone);
    }
}