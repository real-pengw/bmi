using System;
using System.Windows.Forms;

namespace bmi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double Height;
        public double Weight;

        private void UpdateHeight()
        {
            if (double.TryParse(textBox1.Text, out double parsedHeight))
            {
                // If radioButton2 (cm) is checked, convert cm to meters
                Height = radioButton2.Checked ? parsedHeight / 100.0 : parsedHeight;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateHeight();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateHeight();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Re-check height in case the user typed in textBox1 after clicking a radio button
            UpdateHeight();

            if (!double.TryParse(textBox2.Text, out Weight) || Height <= 0)
            {
                label2.Text = "Please enter valid numeric values.";
                return;
            }

            double bmi = Weight / (Height * Height);

            // Using chained else-if guarantees only ONE block executes
            if (bmi >= 27)
            {
                label2.Text = $"BMI: {bmi:F2}，肥胖";
            }
            else if (bmi >= 24)
            {
                label2.Text = $"BMI: {bmi:F2}，過重";
            }
            else if (bmi >= 18.5)
            {
                label2.Text = $"BMI: {bmi:F2}，健康";
            }
            else
            {
                label2.Text = $"BMI: {bmi:F2}，過輕";
            }
        }
    }
}