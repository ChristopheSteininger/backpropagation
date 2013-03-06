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
        private Network network;
        private TrainerIO io = new PolarToCartesianIO();
        private Trainer trainer;

        private int totalIterations = 0;

        private BackgroundWorker trainingWorker = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();

            numNeurons.Value = io.MedialNeurons;
            numLayers.Value = io.Layers;
            numRate.Value = (decimal)io.LearningRate;
            ResetNetwork();

            lblTrainingProgress.Text = "";
            RunTest();

            MinimumSize = Size;

            trainingWorker.WorkerReportsProgress = true;
            trainingWorker.WorkerSupportsCancellation = true;
            trainingWorker.DoWork += trainingWorker_DoWork;
            trainingWorker.ProgressChanged += trainingWorker_ProgressChanged;
            trainingWorker.RunWorkerCompleted += trainingWorker_RunWorkerCompleted;
        }

        private void trainingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblTrainingProgress.Text = "Training: "
                + (totalIterations + e.ProgressPercentage).ToString();
        }

        private void trainingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int iterations = (int)numTrainingSize.Value;

            lineGraph.SetData(trainer.Train(iterations, trainingWorker, chPrintData.Checked));

            totalIterations += iterations;
        }

        private void trainingWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            RunTest();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            if (!trainingWorker.IsBusy)
            {
                trainingWorker.RunWorkerAsync();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetNetwork();
        }

        private void numR_ValueChanged(object sender, EventArgs e)
        {
            RunTest();
        }

        private void numTheta_ValueChanged(object sender, EventArgs e)
        {
            numTheta.Value = Math.Min(numTheta.Value, (decimal)(Math.PI * 0.25));
            RunTest();
        }

        private void RunTest()
        {
            double[] inputs = new double[] { (double)numR.Value, (double)numTheta.Value };

            double[] outputs = network.GetOutput(inputs);
            double[] expected = io.GetExpectedOutput(inputs);

            lblResult.Text = String.Format("x = {0:0.00000} y = {1:0.00000}",
                outputs[0], outputs[1]);

            lblActual.Text = String.Format("x = {0:0.00000} y = {1:0.00000}",
                expected[0], expected[1]);

            double errorX = (outputs[0] - expected[0]) / expected[0];
            double errorY = (outputs[1] - expected[1]) / expected[1];
            lblErrors.Text = String.Format("E(x) = {0:P1}, E(y) = {1:P1}, ET = {2:P1}",
                errorX, errorY, Math.Sqrt(Math.Pow(errorX, 2) + Math.Pow(errorY, 2)));

        }

        private void ResetNetwork()
        {
            network = new Network(io.Inputs, io.Outputs, (int)numNeurons.Value,
                (int)numLayers.Value);
            trainer = new Trainer(network, io);
            trainer.LearningRate = (double)numRate.Value;

            totalIterations = 0;
            lblTrainingProgress.Text = "";

            lineGraph.SetData(null);
            lineGraph.Refresh();
        }
    }
}
