using System;
using System.Collections.Generic;
using System.Text;

namespace tester
{
    public class Cat :Animal
    {
        public Cat(string color, int age) : base(color, age) { }

        public override string MakeSound()
        {
            return "ebanie";
        }
    }
}
