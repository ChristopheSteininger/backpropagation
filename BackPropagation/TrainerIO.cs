using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackPropagation
{
    /// <summary>
    /// An abstract class to define the input and output functions which
    /// all trainer IOs must provide as well as a random number generator
    /// to get random inputs.
    /// </summary>
    abstract class TrainerIO
    {
        protected Random random = new Random();

        public abstract double[] GetExpectedOutput(double[] input);

        public abstract double[] GetValidInput();
    }
}
