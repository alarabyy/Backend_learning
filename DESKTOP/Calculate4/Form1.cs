using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Form1 : Form
    {

        string operating = "";
        double resulte = 0;
        bool isoperating = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (textBox1.Text == "0" || isoperating == true )
            {
                textBox1.Clear();
            }
            if(button.Text == ".")
            {
                if(!textBox1.Text.Contains("."))
                {
                    textBox1.Text = textBox1.Text + button.Text;

                }

            }
            else
            {
                textBox1.Text = textBox1.Text + button.Text;
            }
            isoperating = false;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operating = button.Text;
            resulte = double.Parse(textBox1.Text);
            isoperating =  true;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            switch (operating) 
            {
                case "+":
                    textBox1.Text = (resulte + double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (resulte - double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    textBox1.Text = (resulte / double.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (resulte * double.Parse(textBox1.Text)).ToString();
                    break;


            }

         
            }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            resulte = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }
