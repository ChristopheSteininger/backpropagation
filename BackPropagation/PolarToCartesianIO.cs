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
        /// Gets the suggested learning rate for this behaviour.
        /// </summary>
        public double LearningRate { get { return 0.02; } }

        /// <summary>
        /// Gets the number of inputs for this behaviour.
        /// </summary>
        public int Inputs { get { return 2; } }

        /// <summary>
        /// Gets the number of outputs for this behaviour.
        /// </summary>
        public int Outputs { get { return 2; } }

        /// <summary>
        /// Gets the suggested number of medial numbers for this behaviour.
        /// </summary>
        public int MedialNeurons { get { return 40; } }

        private Random random = new Random();

        /// <summary>
        /// Returns the cartesian representation of the polar input.
        /// Pre: Input length is 2.
        /// </summary>
        /// <param name="input">The polar coordinate. The first element
        /// is the value for r, the second is theta</param>
        /// <returns>The cartesian representation</returns>
        public double[] GetExpectedOutput(double[] input)
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
        public double[] GetValidInput()
        {
            double r = random.NextDouble();
            double theta = random.NextDouble() * 0.25 * Math.PI;

            return new double[] { r, theta };
        }

        /// <summary>
        /// Returns a network with the correct number of inputs and outputs,
        /// as well as the suggested number of medial neurons.
        /// </summary>
        /// <returns>The valid network</returns>
        public Network GetValidNetwork()
        {
            return new Network(Inputs, Outputs, MedialNeurons);
        }
    }
}
