namespace BackPropagation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupTraining = new System.Windows.Forms.GroupBox();
            this.chPrintData = new System.Windows.Forms.CheckBox();
            this.lblTrainingProgress = new System.Windows.Forms.Label();
            this.lineGraph = new BackPropagation.LineGraph();
            this.btnTrain = new System.Windows.Forms.Button();
            this.numTrainingSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblErrors = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblActual = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numTheta = new System.Windows.Forms.NumericUpDown();
            this.numR = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbNetwork = new System.Windows.Forms.GroupBox();
            this.numRate = new System.Windows.Forms.NumericUpDown();
            this.numLayers = new System.Windows.Forms.NumericUpDown();
            this.numNeurons = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupTraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTrainingSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTheta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numR)).BeginInit();
            this.gbNetwork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNeurons)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTraining
            // 
            this.groupTraining.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTraining.Controls.Add(this.chPrintData);
            this.groupTraining.Controls.Add(this.lblTrainingProgress);
            this.groupTraining.Controls.Add(this.lineGraph);
            this.groupTraining.Controls.Add(this.btnTrain);
            this.groupTraining.Controls.Add(this.numTrainingSize);
            this.groupTraining.Controls.Add(this.label5);
            this.groupTraining.Location = new System.Drawing.Point(12, 136);
            this.groupTraining.Name = "groupTraining";
            this.groupTraining.Size = new System.Drawing.Size(637, 356);
            this.groupTraining.TabIndex = 0;
            this.groupTraining.TabStop = false;
            this.groupTraining.Text = "Training";
            // 
            // chPrintData
            // 
            this.chPrintData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chPrintData.AutoSize = true;
            this.chPrintData.Checked = true;
            this.chPrintData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chPrintData.Cursor = System.Windows.Forms.Cursors.Default;
            this.chPrintData.Location = new System.Drawing.Point(18, 333);
            this.chPrintData.Name = "chPrintData";
            this.chPrintData.Size = new System.Drawing.Size(153, 17);
            this.chPrintData.TabIndex = 12;
            this.chPrintData.Text = "Print training data to log file";
            this.chPrintData.UseVisualStyleBackColor = true;
            // 
            // lblTrainingProgress
            // 
            this.lblTrainingProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrainingProgress.AutoSize = true;
            this.lblTrainingProgress.Location = new System.Drawing.Point(121, 299);
            this.lblTrainingProgress.Name = "lblTrainingProgress";
            this.lblTrainingProgress.Size = new System.Drawing.Size(67, 13);
            this.lblTrainingProgress.TabIndex = 11;
            this.lblTrainingProgress.Text = "PROGRESS";
            // 
            // lineGraph
            // 
            this.lineGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lineGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineGraph.Location = new System.Drawing.Point(18, 50);
            this.lineGraph.Name = "lineGraph";
            this.lineGraph.Size = new System.Drawing.Size(613, 236);
            this.lineGraph.TabIndex = 10;
            // 
            // btnTrain
            // 
            this.btnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrain.Location = new System.Drawing.Point(18, 292);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(97, 26);
            this.btnTrain.TabIndex = 9;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // numTrainingSize
            // 
            this.numTrainingSize.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTrainingSize.Location = new System.Drawing.Point(103, 24);
            this.numTrainingSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTrainingSize.Name = "numTrainingSize";
            this.numTrainingSize.Size = new System.Drawing.Size(108, 20);
            this.numTrainingSize.TabIndex = 1;
            this.numTrainingSize.ThousandsSeparator = true;
            this.numTrainingSize.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Training size:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblErrors);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblActual);
            this.groupBox2.Controls.Add(this.lblResult);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numTheta);
            this.groupBox2.Controls.Add(this.numR);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 498);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 109);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test";
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(262, 81);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(53, 13);
            this.lblErrors.TabIndex = 9;
            this.lblErrors.Text = "ERRORS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(206, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Errors:";
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.Location = new System.Drawing.Point(262, 53);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(49, 13);
            this.lblActual.TabIndex = 7;
            this.lblActual.Text = "ACTUAL";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(262, 27);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(50, 13);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "RESULT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Actual:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Result:";
            // 
            // numTheta
            // 
            this.numTheta.DecimalPlaces = 2;
            this.numTheta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numTheta.Location = new System.Drawing.Point(52, 51);
            this.numTheta.Name = "numTheta";
            this.numTheta.Size = new System.Drawing.Size(108, 20);
            this.numTheta.TabIndex = 3;
            this.numTheta.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numTheta.ValueChanged += new System.EventHandler(this.numTheta_ValueChanged);
            // 
            // numR
            // 
            this.numR.DecimalPlaces = 2;
            this.numR.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numR.Location = new System.Drawing.Point(52, 25);
            this.numR.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numR.Name = "numR";
            this.numR.Size = new System.Drawing.Size(108, 20);
            this.numR.TabIndex = 2;
            this.numR.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numR.ValueChanged += new System.EventHandler(this.numR_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "theta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "r:";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(517, 70);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 31);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // gbNetwork
            // 
            this.gbNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNetwork.Controls.Add(this.numRate);
            this.gbNetwork.Controls.Add(this.btnReset);
            this.gbNetwork.Controls.Add(this.numLayers);
            this.gbNetwork.Controls.Add(this.numNeurons);
            this.gbNetwork.Controls.Add(this.label8);
            this.gbNetwork.Controls.Add(this.label7);
            this.gbNetwork.Controls.Add(this.label6);
            this.gbNetwork.Location = new System.Drawing.Point(12, 12);
            this.gbNetwork.Name = "gbNetwork";
            this.gbNetwork.Size = new System.Drawing.Size(631, 118);
            this.gbNetwork.TabIndex = 3;
            this.gbNetwork.TabStop = false;
            this.gbNetwork.Text = "Network";
            // 
            // numRate
            // 
            this.numRate.DecimalPlaces = 3;
            this.numRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numRate.Location = new System.Drawing.Point(103, 77);
            this.numRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRate.Name = "numRate";
            this.numRate.Size = new System.Drawing.Size(108, 20);
            this.numRate.TabIndex = 15;
            this.numRate.ThousandsSeparator = true;
            this.numRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numLayers
            // 
            this.numLayers.Location = new System.Drawing.Point(103, 51);
            this.numLayers.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numLayers.Name = "numLayers";
            this.numLayers.Size = new System.Drawing.Size(108, 20);
            this.numLayers.TabIndex = 14;
            this.numLayers.ThousandsSeparator = true;
            this.numLayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numNeurons
            // 
            this.numNeurons.Location = new System.Drawing.Point(103, 25);
            this.numNeurons.Name = "numNeurons";
            this.numNeurons.Size = new System.Drawing.Size(108, 20);
            this.numNeurons.TabIndex = 13;
            this.numNeurons.ThousandsSeparator = true;
            this.numNeurons.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Learning rate:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Medial layers:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Medial neurons:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 619);
            this.Controls.Add(this.gbNetwork);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupTraining);
            this.Name = "Form1";
            this.Text = "Back Propagation";
            this.groupTraining.ResumeLayout(false);
            this.groupTraining.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTrainingSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTheta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numR)).EndInit();
            this.gbNetwork.ResumeLayout(false);
            this.gbNetwork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNeurons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTraining;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numTheta;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTrainingSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTrain;
        private LineGraph lineGraph;
        private System.Windows.Forms.Label lblTrainingProgress;
        private System.Windows.Forms.CheckBox chPrintData;
        private System.Windows.Forms.GroupBox gbNetwork;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numRate;
        private System.Windows.Forms.NumericUpDown numLayers;
        private System.Windows.Forms.NumericUpDown numNeurons;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.Label label9;
    }
}

