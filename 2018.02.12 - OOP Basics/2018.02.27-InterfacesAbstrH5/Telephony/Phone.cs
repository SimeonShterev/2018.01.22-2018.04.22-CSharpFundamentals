using System;
using System.Collections.Generic;
using System.Text;

public class Phone : ISite, INumber
{
    private Queue<string> numbersQueue;
    private Queue<string> sitesQueue;

    public Phone()
    {
        numbersQueue = new Queue<string>();
        sitesQueue = new Queue<string>();
    }

    public void CheckNumber(string number)
    {
        int lenght = number.Length;
        for (int i = 0; i < lenght; i++)
        {
            if (!char.IsDigit(number[i]))
            {
                this.numbersQueue.Enqueue("Invalid number!");
                return;
            }
        }
        this.numbersQueue.Enqueue("Calling... " + number);
    }

    public void CheckSite(string site)
    {
        int lenght = site.Length;
        for (int i = 0; i < lenght; i++)
        {
            if (char.IsDigit(site[i]))
            {
                this.sitesQueue.Enqueue("Invalid URL!");
                return;
            }
        }
        this.sitesQueue.Enqueue("Browsing: " + site + "!");
    }

    public override string ToString()
    {
        while (this.numbersQueue.Count != 0)
        {
            Console.WriteLine(numbersQueue.Dequeue());
        }
        while (this.sitesQueue.Count != 0)
        {
            Console.WriteLine(sitesQueue.Dequeue());
        }
        return string.Empty;
    }
}