using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("please enter value");
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
            }
            label3.Text = textBox1.Text + textBox2.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text =="" && textBox2.Text == "")
            {
                MessageBox.Show("please enter value");
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
            }
            int N1  = Convert.ToInt32(textBox1.Text);
            int N2 = Convert.ToInt32(textBox2.Text);
            int RESULT = N1 + N2;
            label4.Text = Convert.ToString(RESULT);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int N1 = Convert.ToInt32(textBox1.Text);
            int N2 = Convert.ToInt32(textBox2.Text);
            int RESULT = N1 - N2;
            label5.Text = Convert.ToString(RESULT);    
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(textBox1.Text);
            double n2 = double.Parse(textBox2.Text);
            double RESULT = n1 / n2;
            label7.Text = Convert.ToString(RESULT);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(textBox1.Text);
            double n2 = double.Parse(textBox2.Text);
            double RESULT = n1 * n2;
            label6.Text = Convert.ToString(RESULT);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label8_Click(object sender, EventArgs e)
        {
      
        }

        private void button6_Click(object sender, EventArgs e)
        {

             if (textBox3.Text == string.Empty)
            {

                MessageBox.Show("please enter value");
                label8.BackColor = Color.Red;

            }
            int total = Convert.ToInt32(textBox3.Text);

            if (total < 50)
            {
                label8.Text = "faild";
                label8.BackColor = Color.Red;
            }
            else if (total < 65)
            {
                label8.Text = "pass";
                label8.BackColor = Color.Green;
            }
            else if (total < 75)
            {
                label8.Text = "good";
                label8.BackColor = Color.Blue;
            }
            else if (total < 85)
            {
                label8.Text = "very  good";
                label8.BackColor = Color.Transparent;
            }
            else
            {
                label8.Text = "exlante";
                label8.BackColor = Color.Gold;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string test = comboBox1.Text;
            switch (test) 
            {
                case "alex":
                    label9.Text = "number_1";
                    break;
                case "cairo":
                    label9.Text = "number _2";
                    break ;
                case "aswan":
                    label9.Text = "number_3";
                    break ;
                default:
                    label9.Text = "no think any way";
                    break;
            
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
