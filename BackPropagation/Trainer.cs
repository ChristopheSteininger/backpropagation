using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;

namespace BackPropagation
{
    class Trainer
    {
        /// <summary>
        /// The filename to write the log to.
        /// </summary>
        private const string logFile = "training.log";

        /// <summary>
        /// The network to train.
        /// </summary>
        private readonly Network network;

        /// <summary>
        /// The input/output to train the network against.
        /// </summary>
        private readonly TrainerIO io;

        /// <summary>
        /// Creates a new instance of trainer with the network to train and
        /// the input/output to train for.
        /// </summary>
        /// <param name="network"></param>
        /// <param name="io"></param>
        public Trainer(Network network, TrainerIO io)
        {
            this.network = network;
            this.io = io;
        }

        /// <summary>
        /// Trains the network, and writes to the log file if specified.
        /// </summary>
        /// <param name="iterations">The number of train-test repetitions</param>
        /// <param name="worker">The background work to report progress to</param>
        /// <param name="printData">Prints test number, input, expected and
        /// actual output, error and total error to the log file if true</param>
        /// <returns>The total error of each repetition</returns>
        public double[] Train(int iterations, BackgroundWorker worker, bool printData)
        {
            StreamWriter writer = null;

            // Open the log file if the method should write to it.
            if (printData)
            {
                writer = new StreamWriter(logFile);
                writer.WriteLine("Test\tInputs\t\tExpected"
                    + "\t\tActual\t\tError\t\tTotal Error");
            }

            double[] allErrors = new double[iterations];
            double[] inputs, expected, actual, errors;

            // Train and test the network for the given number of times.
            for (int i = 0; i < iterations; i++)
            {
                // Get the input and expected output from the IO.
                inputs = io.GetValidInput();
                expected = io.GetExpectedOutput(inputs);

                // Get the actual output of the network.
                actual = network.GetOutput(inputs);

                // Get the error for each output in the network.
                errors = GetError(expected, actual);

                // TODO: Remove fixed learning rate.
                // Apply the back propagation algorithm.
                BackPropagation(inputs, errors, 0.01);

                // TODO: Calculate allErrors for any length number of errors.
                // Calculate the total error as summation in quadrature.
                allErrors[i] = Math.Sqrt(Math.Pow(errors[0], 2)
                    + Math.Pow(errors[1], 2));

                // Report progress every 1,000 iterations to the worker.
                if (i % 1000 == 0)
                {
                    worker.ReportProgress(i);
                }

                // TODO: average each value over the 20 iterations.
                // Print every 20th iteration to the log file.
                if (printData && i % 10 == 0)
                {
                    writer.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",
                        i, inputs[0], inputs[1], expected[0], expected[1], actual[0],
                        actual[1], errors[0], errors[1], allErrors[i]);
                }
            }

            // Close the writer if the log file was updated.
            if (printData)
            {
                writer.Close();
            }

            // Report finished to worker.
            worker.ReportProgress(iterations);

            return allErrors;
        }

        /// <summary>
        /// Calculates the difference between each expected and actual output.
        /// Pre: The lengths of the outputs are the same.
        /// </summary>
        /// <param name="expected">The expected outputs</param>
        /// <param name="actual">The actual outputs</param>
        /// <returns>The difference between the outputs</returns>
        private double[] GetError(double[] expected, double[] actual)
        {
            Debug.Assert(expected.Length == actual.Length, "Parameter lengths must be equal.");

            double[] errors = new double[expected.Length];
            for (int i = 0; i < expected.Length; i++)
            {
                errors[i] = expected[i] - actual[i];
            }

            return errors;
        }

        /// <summary>
        /// Applies the back propagation algorithm to the network.
        /// </summary>
        /// <param name="inputs">The input to the network</param>
        /// <param name="errors">The errors on the ouput</param>
        /// <param name="rate">The learning rate</param>
        private void BackPropagation(double[] inputs, double[] errors, double rate)
        {
            // Adjust the weights between the medial and output layer.
            for (int output = 0; output < network.Outputs; output++)
            {
                for (int neuron = 0; neuron < network.Neurons; neuron++)
                {
                    network.SynTwo[neuron, output] += rate * network.Medout[neuron]
                        * errors[output];
                }
            }

            // Calculate the internal error of each medial neuron and store in
            // sigma. Store the gradient of the sigmoid function at the value in sigma
            // in sigmoid.
            double[] sigma = new double[network.Neurons];
            double[] sigmoid = new double[network.Neurons];
            for (int neuron = 0; neuron < network.Neurons; neuron++)
            {
                sigma[neuron] = 0;
                for (int output = 0; output < network.Outputs; output++)
                {
                    sigma[neuron] += errors[output] * network.SynTwo[neuron, output];
                }

                sigmoid[neuron] = dLogistic(network.Medin[neuron]);
            }

            for (int input = 0; input < network.Inputs; input++)
            {
                for (int neuron = 0; neuron < network.Neurons; neuron++)
                {
                    network.SynOne[input, neuron]
                        += rate * sigmoid[neuron] * sigma[neuron] * inputs[input];
                }
            }
        }

        /// <summary>
        /// Returns the value of the derivative of the logistic function with
        /// at given value for x.
        /// </summary>
        /// <param name="x">The value for x</param>
        /// <returns>The value of d(logistic(x))/dx</returns>
        private double dLogistic(double x)
        {
            //return 1.0 - Math.Pow(x, 2);
            return Math.Exp(x) / Math.Pow(Math.Exp(x) + 1, 2);
        }
    }
}
