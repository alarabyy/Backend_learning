using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Person_data_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("id is not fill", "ERRPR", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else
            {
                StreamReader sr = new StreamReader("Data.txt");
                string line ="";
                bool found = false;

                do
                {
                    line = sr.ReadLine();
                    if(line != null)
                    {
                        string[] arr =line.Split(';');
                        if (arr[0] == textBox1.Text)
                        {
                            textBox1.Text = arr[0];
                            textBox2.Text = arr[1];
                            textBox3.Text = arr[2];
                            textBox4.Text = arr[3];
                            textBox5.Text = arr[4];
                            found = true;
                            break;
                        }
                    }

                }
                while(line != null);
                sr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim()=="" ||
                textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" ||
                textBox5.Text.Trim() == "" )
            {
                MessageBox.Show("please fill space","ERROR",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
            }
            StreamReader SR = new StreamReader("Data.txt", true);
            string STR = SR.ReadToEnd();
            SR.Close();

            if (STR.Contains(textBox1.Text + ";"))
            {
                MessageBox.Show(" this id is exist");
                textBox1.Focus();
                textBox1.Select();
            }
            else
            {

                StreamWriter sw = new StreamWriter("Data.txt", true);
                string mydata = textBox1.Text + ";"
                              + textBox2.Text + ";"
                              + textBox3.Text + ";"
                              + textBox4.Text + ";"
                              + textBox5.Text + ";";
                sw.WriteLine(mydata);
                sw.Close();
                MessageBox.Show("data is added");
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
                textBox1.Focus();
                {

                }
            }



        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            File.WriteAllText("Data.txt",string.Empty);
            MessageBox.Show("data was cleared !!","file was clear",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            TextBox textBx = new TextBox();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Size = this.Size;
            frm.Font = this.Font;
            frm.Icon = this.Icon;
            frm.Text = "all data";
            textBx.Dock = DockStyle.Fill;
            textBx.Multiline = true;
            frm.Controls.Add(textBx);




            try
            {
                StreamReader str = new StreamReader("Data.txt");
                string strall = str.ReadToEnd();
                str.Close();
                textBx.Text = strall;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            frm.ShowDialog();

        }
    }
}
