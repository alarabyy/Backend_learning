using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private string message;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public string hello()
        {
            return  message = "hello and welcome ";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == "0")
            //{
            //    MessageBox.Show("please enter your language");
            //}
            //else
            //{
            //    label2.Text = hello() + textBox1.Text;
            //    string message2 = hello() + " C# ";

            //}
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("please enter your language","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                label2.Text = hello() + textBox1.Text;
                string message2 = hello() + " C# ";

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox4.Text);
            int y = int.Parse(textBox5.Text);

            button6.Location = new Point(x, y);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox3.Text);
            int y = int.Parse(textBox6.Text);

            button7.Left = x;
            button7.Top = y;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Left -= 5;
            this.Top -= 5;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Left += 5;
            this.Top += 5;

        }
    }
}
