using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BackPropagation
{
    class Trainer
    {
        private readonly Network network;

        public delegate double[] ExpectedOutputDelegate(double[] inputs);
        public delegate double[] GetValidInputDelegate();

        public Trainer(Network network)
        {
            this.network = network;
        }

        public double[] Train(ExpectedOutputDelegate expectedOutput,
            GetValidInputDelegate getValidInput, int iterations)
        {
            Random random = new Random();

            double[] allErrors = new double[iterations];

            double[] inputs, expected, actual, errors;
            for (int i = 0; i < iterations; i++)
            {
                inputs = getValidInput();

                expected = expectedOutput(inputs);
                actual = network.GetOutput(inputs);

                errors = GetError(expected, actual);

                BackPropagation(inputs, errors, 0.1);

                allErrors[i] = Math.Sqrt(Math.Pow(errors[0], 2) + Math.Pow(errors[1], 2));
            }

            return allErrors;
        }

        private double[] GetError(double[] expected, double[] actual)
        {
            Debug.Assert(expected.Length == actual.Length, "Parameter lengths must be equal.");

            double[] errors = new double[expected.Length];
            for (int i = 0; i < expected.Length; i++)
            {
                errors[i] = actual[i] - expected[i];
            }

            return errors;
        }

        private void BackPropagation(double[] inputs, double[] errors, double rate)
        {
            for (int output = 0; output < network.Outputs; output++)
            {
                for (int neuron = 0; neuron < network.Neurons; neuron++)
                {
                    network.SynTwo[neuron, output] += rate * network.Medout[neuron] * errors[output];
                }
            }

            double[] sigma = new double[network.Neurons];
            double[] sigmoid = new double[network.Neurons];
            for (int neuron = 0; neuron < network.Neurons; neuron++)
            {
                sigma[neuron] = 0;
                for (int output = 0; output < network.Outputs; output++)
                {
                    sigma[neuron] += errors[output] * network.SynTwo[neuron, output];
                }

                sigmoid[neuron] = 1 - Math.Pow(network.Medin[neuron], 2);
            }

            double delta;
            for (int input = 0; input < network.Inputs; input++)
            {
                for (int neuron = 0; neuron < network.Neurons; neuron++)
                {
                    delta = rate * sigmoid[neuron] * sigma[neuron] * inputs[input];
                    network.SynOne[0, neuron] = network.SynOne[input, neuron] + delta;
                    network.SynOne[1, neuron] = network.SynOne[input, neuron] + delta;
                }
            }
        }
    }
}
