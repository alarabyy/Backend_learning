using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace combo_box_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked ) {
                label1.Text = "check box true";
                
            }
            else
            {
                label1.Text = "check box false";

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("fill text box", "eror", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                int x = int.Parse(textBox1.Text);
                int y = int.Parse(textBox2.Text);

                for (int i = x; i < y; i++)
                {
                    comboBox1.Items.Add(i);
                }
            }


            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("fill text box", "eror", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                int x = int.Parse(textBox1.Text);
                int y = int.Parse(textBox2.Text);

                for (int i = x; i < y; i++)
                {
                    checkedListBox1.Items.Add(i);
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                MessageBox.Show(checkedListBox1.CheckedItems[i].ToString());
            }
        }
    }
}
