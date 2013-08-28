using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataReduction
{
    public partial class Plot : Form
    {
        public Plot()
        {
            InitializeComponent();
        }

        private void Plot_Load(object sender, EventArgs e)
        {

        }

        public void Initialize_Plot(List<double> X, List<double> Y)
        {
            chart1.Series.Add("Load vs. Displacement");


            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            for (int i = 0; i < X.Count; i++)
            {
                chart1.Series[0].Points.AddXY(X[i], Y[i]);
            }

            chart1.Titles.Add("Static Axial Compression - 752028-F1");
            chart1.Titles[0].Font = new Font("Garamond", 12.0f);

            chart1.ChartAreas[0].AxisY.Minimum =  Y.Min();
            chart1.ChartAreas[0].AxisY.Maximum =  Y.Max();
            chart1.ChartAreas[0].AxisX.Minimum =  X.Min();
            chart1.ChartAreas[0].AxisX.Maximum =  X.Max();

            chart1.ChartAreas[0].AxisX.Interval = 0.10;
            chart1.ChartAreas[0].AxisY.Interval = 2000;

            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#";
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "#.##";

            chart1.Series[0].IsVisibleInLegend = false;

            chart1.ChartAreas[0].AxisX.Title = "Position, mm";
            chart1.ChartAreas[0].AxisX.TitleFont = new Font("Garamond", 12.0f);
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("Garamond", 12.0f);
            chart1.ChartAreas[0].AxisY.Title = "Load, N";

            chart1.Show();
        }

        
    }
}
