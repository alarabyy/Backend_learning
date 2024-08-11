using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System_school.Students; 

namespace System_school
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }
        contextdatabase database = new contextdatabase();
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
          OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            pictureBox2.ImageLocation = open.FileName;
            label1.Text = open.FileName;
            label3.Text = Path.GetFileName(open.FileName);


          
            //==============================================
            MessageBox.Show("done added :)");


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox22.SelectedItem == null)
            {
                MessageBox.Show("Please select a grade from the combo box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Students students = new Students
            {
                Firstname = textFirstname.Text,
                Lastname = textLastname.Text,
                Studentnumber = textBox33.Text,
                Birthdate = dateTimePicker11.Value,
                JoinDate = dateTimePicker22.Value,
                Grades = (Grade)Enum.Parse(typeof(Grade), comboBox22.SelectedItem.ToString())
            };

            label9.Text = students.Report();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            foreach (string item in Enum.GetNames(typeof(Students.Grade)))
            {
                comboBox22.Items.Add(item);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("your data added in database :)");

            Deparmentt dep1 = new Deparmentt();
            dep1.Fullname = textFirstname.Text + " " + textLastname.Text;
            dep1.Studentcode =  Convert.ToInt32(textBox33.Text);
            dep1.Grade = comboBox22.SelectedIndex.ToString();
            dep1.birthdate = dateTimePicker11.Value;    
            dep1.Joindate = dateTimePicker22.Value;
            dep1.nameimg = label3.Text;
            database.Deparmentts.Add(dep1);
            database.SaveChanges();

            //==============================================  to slice img

            FileStream stream = new FileStream(label1.Text, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            FileInfo fileInfo = new FileInfo(label1.Text);
            dep1.img = reader.ReadBytes((int)fileInfo.Length);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
