using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        public int myage()
        {
            int yearDifference = DateTime.Now.Year - DateTime.Parse(dateTimePicker1.Text).Year;
            return yearDifference;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string myname = textBox1.Text;
            string myadress = textBox2.Text;
            label1.Text ="my name: " +myname + " and my adress :" + myadress + " and my birthday:" + dateTimePicker1.Text + " and my age:"+ myage();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = (int.Parse(numericUpDown1.Text) + int.Parse(numericUpDown2.Text)).ToString();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("[dd:MM:yyyy]:[HH:mm:ss]");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            int val = trackBar1.Value;
            label2.Text = val.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("welcome in my app","Hello...", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
        }
    }
}
