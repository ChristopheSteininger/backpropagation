﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackPropagation
{
    public partial class LineGraph : UserControl
    {
        private double[] data;
        public double[] Data { get { return data; } }

        public LineGraph()
        {
            InitializeComponent();
        }

        public void SetData(double[] data)
        {
            this.data = data;
            DrawGraph(CreateGraphics());
        }

        private void LineGraph_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph(e.Graphics);
        }

        private void DrawGraph(Graphics graphics)
        {
            if (data == null)
            {
                return;
            }

            graphics.Clear(BackColor);

            int yAxisLines = 10;
            int axisPadding = 30;
            int graphWidth = Width - axisPadding;
            int graphHeight = Height - axisPadding;

            // Average the data.
            int averageLength = Math.Max(data.Length / graphWidth, 1);
            double[] averagedData = new double[graphWidth];

            for (int i = 0; i < averagedData.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < averageLength; j++)
                {
                    sum += data[i * averageLength + j];
                }

                averagedData[i] = sum / averageLength;
            }

            // Draw y axis.
            double maxValue = averagedData.Max();
            Brush axisBrush = new SolidBrush(Color.Gray);
            Pen axisPen = new Pen(axisBrush);

            for (int i = 0; i <= yAxisLines; i++)
            {
                int yPos = graphHeight * i / yAxisLines;
                int xPos = i + axisPadding;
                double label = Math.Round(maxValue - maxValue * i / yAxisLines, 2);

                graphics.DrawLine(axisPen, i + axisPadding, yPos,
                    graphWidth + axisPadding, yPos);

                graphics.DrawString(label.ToString(), Font,
                    axisBrush, new PointF(0, yPos));
            }

            axisPen.Dispose();

            // Draw the averaged data.
            Pen pointPen = new Pen(Color.Black, 1);

            for (int i = 0; i < averagedData.Length; i++)
            {
                int yPos = (int)(averagedData[i] * graphHeight / maxValue);
                int xPos = i + axisPadding;

                graphics.DrawLine(pointPen, xPos, graphHeight,
                    xPos, graphHeight - yPos);
            }

            pointPen.Dispose();
        }
    }
}