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
        private PolarToCartesianIO polarToCartesian = new PolarToCartesianIO();
        private Trainer trainer;

        private int totalIterations = 0;

        private BackgroundWorker trainingWorker = new BackgroundWorker();

        public Form1()
        {
            network = polarToCartesian.GetValidNetwork();
            trainer = new Trainer(network, polarToCartesian);

            InitializeComponent();

            MinimumSize = Size;

            trainingWorker.WorkerReportsProgress = true;
            trainingWorker.WorkerSupportsCancellation = true;
            trainingWorker.DoWork += trainingWorker_DoWork;
            trainingWorker.ProgressChanged += trainingWorker_ProgressChanged;
        }

        void trainingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblTrainingProgress.Text = "Training: "
                + (totalIterations + e.ProgressPercentage).ToString();
        }

        void trainingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int iterations = (int)numTrainingSize.Value;

            lineGraph.SetData(trainer.Train(iterations, trainingWorker, chPrintData.Checked));

            totalIterations += iterations;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            double[] inputs = new double[] { (double)numX.Value, (double)numY.Value };

            double[] outputs = network.GetOutput(inputs);
            double[] expected = polarToCartesian.GetExpectedOutput(inputs);

            lblResult.Text = String.Format(
                "x = {0:0.00000} y = {1:0.00000}", outputs[0], outputs[1]);

            lblActual.Text = String.Format(
                "x = {0:0.00000} y = {1:0.00000}", expected[0], expected[1]);
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            if (!trainingWorker.IsBusy)
            {
                trainingWorker.RunWorkerAsync();
            }
        }
    }
}
