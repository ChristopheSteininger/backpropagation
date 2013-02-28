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
            this.btnRun = new System.Windows.Forms.Button();
            this.lblActual = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupTraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTrainingSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
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
            this.groupTraining.Location = new System.Drawing.Point(12, 12);
            this.groupTraining.Name = "groupTraining";
            this.groupTraining.Size = new System.Drawing.Size(637, 317);
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
            this.chPrintData.Location = new System.Drawing.Point(18, 294);
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
            this.lblTrainingProgress.Location = new System.Drawing.Point(121, 260);
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
            this.lineGraph.Size = new System.Drawing.Size(613, 197);
            this.lineGraph.TabIndex = 10;
            // 
            // btnTrain
            // 
            this.btnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrain.Location = new System.Drawing.Point(18, 253);
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
            this.numTrainingSize.Location = new System.Drawing.Point(90, 24);
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
            this.groupBox2.Controls.Add(this.btnRun);
            this.groupBox2.Controls.Add(this.lblActual);
            this.groupBox2.Controls.Add(this.lblResult);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numY);
            this.groupBox2.Controls.Add(this.numX);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 335);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 135);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(18, 90);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(97, 26);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
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
            // numY
            // 
            this.numY.DecimalPlaces = 2;
            this.numY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numY.Location = new System.Drawing.Point(52, 51);
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(108, 20);
            this.numY.TabIndex = 3;
            // 
            // numX
            // 
            this.numX.DecimalPlaces = 2;
            this.numX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numX.Location = new System.Drawing.Point(52, 25);
            this.numX.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(108, 20);
            this.numX.TabIndex = 2;
            this.numX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(549, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 519);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupTraining);
            this.Name = "Form1";
            this.Text = "Back Propagation";
            this.groupTraining.ResumeLayout(false);
            this.groupTraining.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTrainingSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTraining;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTrainingSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnTrain;
        private LineGraph lineGraph;
        private System.Windows.Forms.Label lblTrainingProgress;
        private System.Windows.Forms.CheckBox chPrintData;
    }
}

