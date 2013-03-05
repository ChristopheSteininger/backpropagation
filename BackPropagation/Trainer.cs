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
        /// <param name="network">The network to train</param>
        /// <param name="io">The input/output to use</param>
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
        /// <param name="printData">Prints test number and average total error
        /// to the log file if true</param>
        /// <returns>The total error of each repetition</returns>
        public double[] Train(int iterations, BackgroundWorker worker, bool printData)
        {
            StreamWriter writer = null;
            double totalErrorSum = 0;
            const int averageSize = 20;

            // Open the log file if the method should write to it.
            if (printData)
            {
                writer = new StreamWriter(logFile);
                writer.WriteLine("Test\tAverage Error");
            }

            double[] allErrors = new double[iterations];
            double[] inputs, expected, actual;

            // Train and test the network for the given number of times.
            for (int i = 0; i < iterations; i++)
            {
                // Get the input and expected output from the IO.
                inputs = io.GetValidInput();
                expected = io.GetExpectedOutput(inputs);

                // Get the actual output of the network.
                actual = network.GetOutput(inputs);

                // Apply the back propagation algorithm.
                TrainTestPass(inputs, expected, actual, io.LearningRate);

                // Calculate the total error as summation in quadrature.
                allErrors[i] = GetTotalError(expected, actual);

                // Report progress every 100 iterations to the worker.
                if (i % 100 == 0)
                {
                    worker.ReportProgress(i);
                }

                // Print the average total error of every 20th
                // iteration to the log file.
                if (printData)
                {
                    totalErrorSum += allErrors[i];

                    if (i % averageSize == 0)
                    {
                        writer.WriteLine("{0}\t{1}", i,
                            totalErrorSum / averageSize);

                        totalErrorSum = 0;
                    }
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
        /// Calculates the total error of the output given the expected result.
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <returns></returns>
        private double GetTotalError(double[] expected, double[] actual)
        {
            Debug.Assert(expected.Length == actual.Length,
                "Parameter lengths must be equal.");

            double sum = 0;
            for (int i = 0; i < expected.Length; i++)
            {
                sum += Math.Pow(expected[i] - actual[i], 2);
            }

            return Math.Sqrt(sum);
        }

        /// <summary>
        /// Applies an interation of the back propagation algorithm to the network.
        /// </summary>
        /// <param name="inputs">The input to the network</param>
        /// <param name="actual">The actual output of the network</param>
        /// <param name="expected">The expected output of the network</param>
        /// <param name="rate">The learning rate</param>
        private void TrainTestPass(double[] inputs, double[] expected,
            double[] actual, double rate)
        {
            Debug.Assert(expected.Length == actual.Length,
                "Expected and actual output lengths must be equal.");

            // Calculate the error.
            double[] errors = new double[actual.Length];
            for (int error = 0; error < actual.Length; error++)
            {
                errors[error] = expected[error] - actual[error];
            }

            // Calculate the delta values for the medial layer.
            double[][] deltas = new double[network.Layers.Length][];
            double[,] weights = network.SynOut;
            double[] neuronOutputs = errors;
            for (int layer = network.Layers.Length - 1; layer >= 0; layer--)
            {
                deltas[layer] = GetDeltaValues(weights, neuronOutputs);

                weights = network.Layers[layer].Weights;
                neuronOutputs = deltas[layer];
            }

            // Adjust weights.
            double[] currentInputs = inputs;
            for (int layer = 0; layer < network.Layers.Length; layer++)
            {
                for (int input = 0; input < currentInputs.Length; input++)
                {
                    for (int neuron = 0; neuron < network.MedialNeurons; neuron++)
                    {
                        network.Layers[layer].Weights[input, neuron] += rate * currentInputs[input]
                            * deltas[layer][neuron] * dLogistic(network.Medout[layer][neuron]);
                    }
                }

                currentInputs = network.Medout[layer];
            }

            // Adjust weights of the last layer.
            for (int neuron = 0; neuron < network.MedialNeurons; neuron++)
            {
                for (int output = 0; output < network.Outputs; output++)
                {
                    network.SynOut[neuron, output] += rate * currentInputs[neuron]
                        * errors[output];
                }
            }

            return;
        }

        /// <summary>
        /// Calculates the delta values of a set of neurons using the synaptic weights
        /// and the output of the neurons at the end of the synapses.
        /// </summary>
        /// <param name="weights">The synaptic weights</param>
        /// <param name="neuronOutputs">The outputs of the neurons and the inputs
        /// during the backwards pass</param>
        /// <returns>The delta values of the inputs to the synapses</returns>
        private double[] GetDeltaValues(double[,] weights, double[] neuronOutputs)
        {
            Debug.Assert(weights.GetLength(1) == neuronOutputs.Length,
                "Number of output neurons in weights array not equal to number of outputs.");

            double[] delta = new double[weights.GetLength(0)];

            for (int input = 0; input < delta.Length; input++)
            {
                double sum = 0;
                for (int output = 0; output < neuronOutputs.Length; output++)
                {
                    sum += weights[input, output] * neuronOutputs[output];
                }

                delta[input] = sum;
            }

            return delta;
        }

        /// <summary>
        /// Returns the value of the derivative of the logistic function with
        /// using the result of the logistic function y where y = 1 / (1 + exp(-x)).
        /// </summary>
        /// <param name="y">The value for y</param>
        /// <returns>The value of dy/dx at y</returns>
        private double dLogistic(double y)
        {
            return y * (1 - y);
        }
    }
}
