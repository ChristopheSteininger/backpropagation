using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackPropagation
{
    abstract class TrainerIO
    {
        protected Random random = new Random();

        public abstract double[] GetExpectedOutput(double[] input);

        public abstract double[] GetValidInput();
    }
}
