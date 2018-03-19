using System;
using System.Collections.Generic;
using System.Text;

public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, double price)
        : base(author, title, price)
    {
        base.Price = price * 1.3;
    }
}