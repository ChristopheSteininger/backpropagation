using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BackPropagation
{
    class PolarToCartesian : TrainerIO
    {
        public override double[] GetExpectedOutput(double[] input)
        {
            Debug.Assert(input.Length == 2, "Wrong input length");

            double r = input[0];
            double theta = input[1];

            double x = r * Math.Cos(theta);
            double y = r * Math.Sin(theta);

            return new double[] { x, y };
        }

        public override double[] GetValidInput()
        {
            double r = nextDouble();
            double theta = nextDouble() * 2 * Math.PI;

            return new double[] { r, theta };
        }

        private double nextDouble()
        {
            return random.Next(1000) / 1000.0;
        }
    }
}
