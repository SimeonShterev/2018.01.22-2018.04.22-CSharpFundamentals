using System;
using System.Collections.Generic;
using System.Text;

public class Tesla : Car, IElectricCar
{
    public Tesla(string model, string color, int batteries) : base(model, color)
    {
        this.Battery = batteries;
    }

    public int Battery { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(this.Color).Append($" {nameof(Tesla)} ").Append(this.Model).AppendLine($" with {this.Battery} Batteries")
            .AppendLine(Start())
            .Append(Stop());
        return sb.ToString();
    }
}
