using System;
using System.Collections.Generic;
using System.Text;

namespace tester
{
    public class Animal
    {
        private string color;
        private int age;

        public Animal(string color, int age)
        {
            this.Age = age;
            this.Color = color;
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public virtual string MakeSound()
        {
            return "Hello";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetType().Name)
                .AppendLine($"Age: {this.Age}")
                .AppendLine($"Color: {this.Color}")
                .AppendLine(MakeSound());

            return sb.ToString();
        }
    }
}
