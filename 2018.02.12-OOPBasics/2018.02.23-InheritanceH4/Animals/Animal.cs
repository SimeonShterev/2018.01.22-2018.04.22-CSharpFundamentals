using System;
using System.Collections.Generic;
using System.Text;

public class Animal : ISoundProducable
{
    private string name;
    private string gender;
    private int age;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if(value<0)
            {
                throw new ArgumentException("Invalid input!");
            }
            this.age = value; }
    }

    public string Gender
    {
        get { return this.gender; }
        set
        {
            switch(value)
            {
                case "Male": this.gender = value; break;
                case "Female": this.gender = value; break;
                default: throw new ArgumentException("Invalid input!");
            }
        }
    }


    public string Name
    {
        get { return this.name; } 
        set { this.name = value; }
    }

    public virtual string ProduceSound()
    {
        return "MakeSomeNoise";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(this.GetType().Name)
            .AppendLine($"{this.name} {this.age} {this.gender}")
            .Append(this.ProduceSound());
        return sb.ToString();
    }
}