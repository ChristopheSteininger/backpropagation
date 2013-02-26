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
        private const string logFile = "training.log";

        private readonly Network network;
        private readonly TrainerIO io;

        private ProgressChangedEventHandler updateProgress;
        public ProgressChangedEventHandler UpdateProgress
        {
            get { return updateProgress; }
            set { updateProgress = value; }
        }

        public Trainer(Network network, TrainerIO io)
        {
            this.network = network;
            this.io = io;
        }

        public double[] Train(int iterations, BackgroundWorker worker, bool printData)
        {
            StreamWriter writer = null;

            if (printData)
            {
                writer = new StreamWriter(logFile);
                writer.WriteLine("Test\tInputs\t\tExpected\t\tActual\t\tError\t\tTotal Error");
            }

            double[] allErrors = new double[iterations];

            double[] inputs, expected, actual, errors;
            for (int i = 0; i < iterations; i++)
            {
                inputs = io.GetValidInput();

                expected = io.GetExpectedOutput(inputs);
                actual = network.GetOutput(inputs);

                errors = GetError(expected, actual);

                BackPropagation(inputs, errors, 0.01);

                allErrors[i] = Math.Sqrt(Math.Pow(errors[0], 2) + Math.Pow(errors[1], 2));

                if (i % 1000 == 0)
                {
                    worker.ReportProgress(i);
                }

                if (printData && i % 20 == 0)
                {
                    writer.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}", i, inputs[0],
                        inputs[1], expected[0], expected[1], actual[0], actual[1], errors[0],
                        errors[1], allErrors[i]);
                }
            }

            if (printData)
            {
                writer.Close();
            }

            worker.ReportProgress(iterations);

            return allErrors;
        }

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
                   // network.SynOne[0, neuron] = network.SynOne[input, neuron] + delta;
                }
            }
        }
    }
}
