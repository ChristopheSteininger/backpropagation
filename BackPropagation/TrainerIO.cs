using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackPropagation
{
    /// <summary>
    /// An interface to define the input and output functions which
    /// all trainer IOs must provide and the number of inputs and output to
    /// the network.
    /// </summary>
    interface TrainerIO
    {
        double LearningRate { get; }

        int Inputs { get; }
        int Outputs { get; }
        int MedialNeurons { get; }

        double[] GetExpectedOutput(double[] input);
        double[] GetValidInput();

        Network GetValidNetwork();
    }
}
