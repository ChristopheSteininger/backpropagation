using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BackPropagation
{
    /// <summary>
    /// Simulates a simple feed forward network with one hidden (medial) layer
    /// containing a variable number of neurons, as well as a variable number
    /// of input and output neurons. The network can also calculate the output
    /// given its inputs.
    /// </summary>
    class Network
    {
        /// <summary>
        /// Gets the synaptic weights between the input and medial neurons.
        /// </summary>
        public double[,] SynOne { get { return synOne; } }
        private double[,] synOne;
        /// <summary>
        /// Gets the synaptic weights between the medial and outpout neurons.
        /// </summary>
        public double[,] SynTwo { get { return synTwo; } }
        private double[,] synTwo;

        /// <summary>
        /// Gets input to each medial neuron.
        /// </summary>
        public double[] Medin { get { return medin; } }
        private double[] medin;

        /// <summary>
        /// Gets the output of each medial neuron.
        /// </summary>
        public double[] Medout { get { return medout; } }
        private double[] medout;

        /// <summary>
        /// Gets the number of neurons in the medial layer.
        /// </summary>
        public int Neurons { get { return neuronCount; } }
        private readonly int neuronCount;

        /// <summary>
        /// Gets the number of inputs to the network.
        /// </summary>
        public int Inputs { get { return inputCount; } }
        private readonly int inputCount;

        /// <summary>
        /// Gets the number of outputs of the network.
        /// </summary>
        public int Outputs { get { return outputCount; } }
        private readonly int outputCount;

        /// <summary>
        /// Creates a new feed forward network with the given number of inputs,
        /// outputs and medial neurons in the network.
        /// </summary>
        /// <param name="inputs">The number of inputs</param>
        /// <param name="outputs">The number of outputs</param>
        /// <param name="neurons">The number of medial neurons</param>
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

        /// <summary>
        /// Calculates the output of the network with the given inputs.
        /// Pre: The length of the input array matches the number of
        /// input neurons.
        /// </summary>
        /// <param name="inputs">The inputs to the network</param>
        /// <returns>The outputs of the network</returns>
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

        /// <summary>
        /// Helper method to set the synaptic weights between two neurons to a small
        /// random value: [0, 0.1).
        /// </summary>
        /// <param name="a">The first dimension of the weights array to return</param>
        /// <param name="b">The second dimension of the weights array to return</param>
        /// <param name="random">The random number generator to use</param>
        /// <returns>A table of synaptic weights</returns>
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
