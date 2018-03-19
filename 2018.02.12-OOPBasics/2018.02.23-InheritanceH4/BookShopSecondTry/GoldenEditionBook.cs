using System;
using System.Collections.Generic;
using System.Text;

public class GoldenEditionBook : Book
{
    private const decimal BookPriceMultiplier = 1.3m ;

    public GoldenEditionBook(string author, string title, decimal price)
        :base(author, title, price)
    {
        this.Price = price * BookPriceMultiplier;
    }
}
