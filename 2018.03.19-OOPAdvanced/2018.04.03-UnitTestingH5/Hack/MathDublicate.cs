using System;
using System.Collections.Generic;
using System.Text;

namespace Hack
{
    public class MathDublicate : IMath
    {
		public double MathAbs(double value)
		{
			double result = Math.Abs(value);
			return result;
		}

		public double MathFloor(double value)
		{
			double result = Math.Floor(value);
			return result;
		}
    }
}
