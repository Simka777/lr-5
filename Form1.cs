using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simpsons_3._8_rule
{
    public partial class Form1 : Form
    {
        Graphics gr;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.UserPaint,
                 true);

            UpdateStyles();

            MainMenu();
        }
        private void MainMenu()
        {
            gr = this.CreateGraphics();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double k = GetNumber(textBox7.Text);
            double st = GetNumber(textBox1.Text);
            double sq = GetNumber(textBox2.Text);
            int stepAmount = (int)GetNumber(textBox4.Text);

            if (stepAmount % 3 != 0)
            {
                MessageBox.Show("step must be aliquot to 3!!!!");
                stepAmount = 3;
            }

            double i0Lim = GetNumber(textBox5.Text);
            double ikLim = GetNumber(textBox6.Text);

            double h = (ikLim - i0Lim) / stepAmount;

            double result = CountFunction(h, stepAmount, k, st, sq, 0);

            textBox3.Text = $"{result}";

            Console.WriteLine(result);
        }

        static double GetNumber(string str)
        {
            if (str == "Pi" || str == "pi" || str == "PI")
            {
                return Math.PI;
            }
            else
            {
                double number;
                bool success = Double.TryParse(str, out number);

                if (success)
                {
                    return number;
                }
                else
                {
                    MessageBox.Show("Enter Number!!!");
                    return 0;
                }
            }
        }

        static double  CountFunction(double h, int step, double k, double st, double sq, double wt0)
        {
            
            double resultH = 3 * h / 8;

            double resultWt = 0;
            int coef;

            for (int i = 0; i < step + 1; i++)
            {
                if (i == 0 || i % 3 == 0)
                {
                    coef = 1;
                }
                else
                {
                    coef = 3;
                }
                double sin= (k* Math.Pow(wt0 +i * h, st) *Math.Sin(sq * Math.Sqrt(wt0 + i * h)));
            resultWt = resultWt + coef * (sin);
            }

            return resultH * resultWt*(-1);
        }

        static double Simpsone(double k, double wt, double wt_)
        {
            return k * Math.Sin(wt * wt_);
        }
    }
}
