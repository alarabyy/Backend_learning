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

namespace _13_System_school
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
 
        }


        private void button3_Click(object sender, EventArgs e)
        {
 
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //=======================================================================================
        //=======================================================================================
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Students students = new Students
            {
                Firstname = textFirstname.Text,
                Lastname = textLastname.Text,
                studentnumber = textBox33.Text,
                birthdate = dateTimePicker11.Value,
                Joindate = dateTimePicker22.Value,
                Grades = (string)comboBox22.SelectedItem,

            };
            label9.Text = students.Report();

        }

        private void Form_Load(object sender, EventArgs e)
        {
            {
                foreach (string items in Enum.GetNames(typeof(Students.Grade)))
                {
                    comboBox22.Items.Add(items);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //=======================================================================================
        //=======================================================================================

    }
}
