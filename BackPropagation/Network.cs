using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BackPropagation
{
    class MedialLayer
    {
        /// <summary>
        /// Gets or sets the weights between the inputs of the layer and the neurons.
        /// </summary>
        public double[,] Weights
        {
            get { return weights; }
            set { weights = value; }
        }
        private double[,] weights;

        /// <summary>
        /// Calculates the output of the layer with the given inputs.
        /// </summary>
        /// <param name="inputs">The inputs to the layer</param>
        /// <returns>The outputs of the neurons</returns>
        public double[] GetOutput(double[] inputs)
        {
            Debug.Assert(inputs.Length == weights.GetLength(0),
                "Input length does not match weight lengths.");

            double[] outputs = new double[weights.GetLength(1)];

            for (int neuron = 0; neuron < outputs.Length; neuron++)
            {
                double sum = 0;

                for (int input = 0; input < inputs.Length; input++)
                {
                    sum += inputs[input] * weights[input, neuron];
                }

                outputs[neuron] = logistic(sum);
            }


            return outputs;
        }

        /// <summary>
        /// Returns the value of a sigmoid function, specifically the logistic function
        /// with the given input x.
        /// </summary>
        /// <param name="x">The value for x</param>
        /// <returns>The value of logistic(x)</returns>
        private double logistic(double x)
        {
            return 1.0 / (1 + Math.Exp(-x));
        }
    }

    /// <summary>
    /// Simulates a simple feed forward network with one hidden (medial) layer
    /// containing a variable number of neurons, as well as a variable number
    /// of input and output neurons. The network can also calculate the output
    /// given its inputs.
    /// </summary>
    class Network
    {
        /// <summary>
        /// Gets the medial layers in the network.
        /// </summary>
        public MedialLayer[] Layers
        {
            get { return layers; }
        }
        private MedialLayer[] layers;

        /// <summary>
        /// Gets the output of each medial neuron.
        /// </summary>
        public double[][] Medout { get { return medout; } }
        private double[][] medout;

        /// <summary>
        /// Gets or sets the weights leading to the output layer.
        /// </summary>
        public double[,] SynOut
        {
            get { return synOut; }
            set { synOut = value; }
        }
        private double[,] synOut;
        
        /// <summary>
        /// Gets the number of neurons in the medial layer.
        /// </summary>
        public int MedialNeurons { get { return neuronCount; } }
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
        public Network(int inputs, int outputs, int neurons, int layers)
        {
            Random random = new Random();

            this.medout = new double[layers][];

            this.neuronCount = neurons;
            this.inputCount = inputs;
            this.outputCount = outputs;

            this.synOut = InitialiseSynArray(neurons, outputs, random);
            this.layers = new MedialLayer[layers];

            for (int i = 0; i < layers; i++)
            {
                int layerInputs = neurons;
                if (i == 0)
                {
                    layerInputs = inputs;
                }

                this.layers[i] = new MedialLayer();
                this.layers[i].Weights = InitialiseSynArray(layerInputs, neurons, random);
            }
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
            for (int layer = 0; layer < layers.Length; layer++)
            {
                medout[layer] = layers[layer].GetOutput(inputs);
                inputs = medout[layer];
            }

            // Calculate the values of the output neurons.
            double[] outputs = new double[outputCount];
            for (int output = 0; output < outputCount; output++)
            {
                outputs[output] = 0;

                for (int neuron = 0; neuron < neuronCount; neuron++)
                {
                    outputs[output] += inputs[neuron] * synOut[neuron, output];
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
                    result[x, y] = random.NextDouble() - 0.5;
                }
            }

            return result;
        }
    }
}
