using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BackPropagation
{
    /// <summary>
    /// Provides the inputs and expected outputs to train a network
    /// in converting polar coordinates the cartesian equivenlent.
    /// </summary>
    class PolarToCartesianIO : TrainerIO
    {
        /// <summary>
        /// Returns the cartesian representation of the polar input.
        /// Pre: Input length is 2.
        /// </summary>
        /// <param name="input">The polar coordinate. The first element
        /// is the value for r, the second is theta</param>
        /// <returns>The cartesian representation</returns>
        public override double[] GetExpectedOutput(double[] input)
        {
            Debug.Assert(input.Length == 2, "Wrong input length");

            double r = input[0];
            double theta = input[1];

            double x = r * Math.Cos(theta);
            double y = r * Math.Sin(theta);

            return new double[] { x, y };
        }

        /// <summary>
        /// Returns a valid, random input to the network, where the first
        /// element gives the value for r: [0, 1) and the second gives
        /// the theta value: [0, 2*PI).
        /// </summary>
        /// <returns>The input to the network</returns>
        public override double[] GetValidInput()
        {
            double r = nextDouble();
            double theta = nextDouble() * 2 * Math.PI;

            return new double[] { r, theta };
        }

        /// <summary>
        /// For testing only. Returns a random double with 3 significant figures.
        /// </summary>
        /// <returns>The random double</returns>
        private double nextDouble()
        {
            return random.Next(1000) / 1000.0;
        }
    }
}
