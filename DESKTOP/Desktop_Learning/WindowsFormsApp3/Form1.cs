using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int day = 1; day < 31; day++)
            {
                comboBox1.Items.Add(day);
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int day = 1; day < 31; day++)
            {
                comboBox1.Items.Add(day);
            }

            for (int month = 1; month < 13; month++)
            {
                comboBox2.Items.Add(month);
            }

            for (int year = DateTime.Now.Year; year > 1900; year--)
            {
                comboBox3.Items.Add(year);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
