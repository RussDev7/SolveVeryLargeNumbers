using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SolveVeryLargeNumbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Generate large number.
        private void Button1_Click(object sender, EventArgs e)
        {
            // Clear controls.
            richTextBox1.Clear();
            progressBar1.Value = 0;

            // Get large number from exponent.
            // Code by: Marc Gravell - https://stackoverflow.com/a/57197337/8667430
            var value = BigInteger.Pow((BigInteger)numericUpDown1.Value, (int)numericUpDown2.Value);

            string s = value.ToString();
            int[] digits = new int[s.Length];
            progressBar1.Maximum = digits.Length;
            for (int i = 0; i < digits.Length; i++)
                digits[i] = s[i] - '0';

            // Write string to richtextbox.
            foreach (int number in digits)
            {
                richTextBox1.AppendText(number.ToString());
                progressBar1.PerformStep();
            }
        }

        // Copy text.
        private void Button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if (richTextBox1.Text != "")
                Clipboard.SetText(richTextBox1.Text);
            progressBar1.Value = progressBar1.Maximum;
        }
    }
}
