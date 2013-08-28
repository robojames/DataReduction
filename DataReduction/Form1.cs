using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace DataReduction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_CSV_1 = new OpenFileDialog();

            open_CSV_1.DefaultExt = "|*.csv";

            open_CSV_1.ShowDialog();

            StreamReader CSV_Reader_1 = new StreamReader(open_CSV_1.FileName);

            string line;
            string[] temp_array;
            int iter = 0;

            List<double> Position_1 = new List<double>();
            List<double> Load_1 = new List<double>();

            while ((line = CSV_Reader_1.ReadLine()) != null)
            {
                if (iter > 3)
                {
                    temp_array = line.Split(',');

                    Position_1.Add(Math.Abs(double.Parse(temp_array[4])));
                    Load_1.Add(Math.Abs(double.Parse(temp_array[5])));
                }

                iter++;
            }

            // Massage the data
            // first the position data
            double Position_1_First = Position_1[0];
            for (int i = 0; i < Position_1.Count; i++)
            {
                Position_1[i] = Position_1[i] - Position_1_First;
            }

            Plot plot_1 = new Plot();
            plot_1.Show();
            plot_1.Initialize_Plot(Position_1, Load_1);
        }
    }
}
