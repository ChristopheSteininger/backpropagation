using System;
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
            double maxValue = data.Max();
            Pen pointPen = new Pen(Color.Black, 1);
            for (int i = 0; i < data.Length; i++)
            {
                int yPos = (int)(data[i] * Height / maxValue);

                graphics.DrawLine(pointPen, i, Height, i, Height - yPos);
            }

            pointPen.Dispose();
        }
    }
}
