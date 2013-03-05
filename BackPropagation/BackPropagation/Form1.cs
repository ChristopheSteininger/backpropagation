using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BackPropagation
{
    public partial class Form1 : Form
    {
        private Network network = new Network(2, 2, 30);
        private Trainer trainer;

        private LineGraph lineGraph;

        public Form1()
        {
            InitializeComponent();

            lineGraph = new LineGraph();
            lineGraph.Size = plGraphPlaceholder.Size;
            lineGraph.Location = plGraphPlaceholder.Location;
            lineGraph.Anchor = plGraphPlaceholder.Anchor;

            groupTraining.Controls.Remove(plGraphPlaceholder);
            groupTraining.Controls.Add(lineGraph);

            MinimumSize = Size;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            double[] inputs = new double[] { (double)numX.Value, (double)numY.Value };

            double[] outputs = network.GetOutput(inputs);
            double[] expected = GetExpected(inputs);

            lblResult.Text = String.Format(
                "r = {0:0.00000} theta = {1:0.00000}", outputs[0], outputs[1]);

            lblActual.Text = String.Format(
                "r = {0:0.00000} theta = {1:0.00000}", expected[0], expected[1]);
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            trainer = new Trainer(network);

            lineGraph.SetData(trainer.Train(GetExpected, GetValidInput, (int)numTrainingSize.Value));
        }

        private double[] GetExpected(double[] input)
        {
            Debug.Assert(input.Length == 2, "Wrong input length");

            double x = input[0];
            double y = input[1];

            double r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            double theta = Math.Atan(y / x);

            return new double[] { r, theta };
        }

        private double[] GetValidInput()
        {
            Random random = new Random();

            return new double[] { random.NextDouble(), random.NextDouble() };
        }
    }
}
