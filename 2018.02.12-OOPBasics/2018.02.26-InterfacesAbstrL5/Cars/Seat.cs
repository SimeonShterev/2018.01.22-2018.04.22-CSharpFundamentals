using System;
using System.Collections.Generic;
using System.Text;

public class Seat : Car
{
    public Seat(string model, string color) : base(model, color) { }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(this.Color).Append($" {nameof(Seat)} ").AppendLine(this.Model)
            .AppendLine(Start())
            .Append(Stop());
        return sb.ToString();
    }
}
