using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BackPropagation
{
    class Network
    {
        private double[,] synOne;
        public double[,] SynOne { get { return synOne; } }

        private double[,] synTwo;
        public double[,] SynTwo { get { return synTwo; } }

        private double[] medin;
        public double[] Medin { get { return medin; } }

        private double[] medout;
        public double[] Medout { get { return medout; } }

        private readonly int neuronCount;
        public int Neurons { get { return neuronCount; } }

        private readonly int inputCount;
        public int Inputs { get { return inputCount; } }

        private readonly int outputCount;
        public int Outputs { get { return outputCount; } }

        public Network(int inputs, int outputs, int neurons)
        {
            Random random = new Random();

            synOne = InitialiseSynArray(inputs, neurons, random);
            synTwo = InitialiseSynArray(neurons, outputs, random);

            this.medin = new double[neurons];
            this.medout = new double[neurons];

            this.neuronCount = neurons;
            this.inputCount = inputs;
            this.outputCount = outputs;
        }

        public double[] GetOutput(double[] inputs)
        {
            Debug.Assert(inputs.Length == inputCount, "Incorrect number of inputs.");

            // Calculate the values of the medial neurons.
            for (int neuron = 0; neuron < neuronCount; neuron++)
            {
                medin[neuron] = 0;

                for (int input = 0; input < inputCount; input++)
                {
                    medin[neuron] += inputs[input] * synOne[input, neuron];
                }

                medout[neuron] = Math.Tanh(medin[neuron]);
            }

            // Calculate the values of the output neurons.
            double[] outputs = new double[outputCount];
            for (int output = 0; output < outputCount; output++)
            {
                outputs[output] = 0;

                for (int neuron = 0; neuron < neuronCount; neuron++)
                {
                    outputs[output] += medout[neuron] * synTwo[neuron, output];
                }
            }

            return outputs;
        }

        private double[,] InitialiseSynArray(int a, int b, Random random)
        {
            double[,] result = new double[a, b];

            for (int y = 0; y < b; y++)
            {
                for (int x = 0; x < a; x++)
                {
                    result[x, y] = 0.1 * random.NextDouble();
                }
            }

            return result;
        }
    }
}
