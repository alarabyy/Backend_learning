using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STORE.DB_LOGIN;

namespace STORE
{
    public partial class SIGNIN : Form
    {
        MyDataContext database = new MyDataContext();
        LoginData lgData = new LoginData();

        public SIGNIN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) &&
                string.IsNullOrWhiteSpace(textBox2.Text) &&
                string.IsNullOrWhiteSpace(textBox3.Text) &&
                string.IsNullOrWhiteSpace(textBox4.Text) &&
                string.IsNullOrWhiteSpace(textBox5.Text)) { 
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

            }
            else {
                lgData.username = textBox1.Text + " " + textBox5.Text;
                lgData.email = textBox2.Text;
                lgData.phone = textBox3.Text;
                lgData.password = textBox4.Text;
                database.LoginDatas.Add(lgData);
                database.SaveChanges();
                MessageBox.Show("signin done :)", "sucssefull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("GO TO LOGIN >> :)", "sucssefull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            var path = ofd.FileName;
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            FileInfo fileInfo = new FileInfo(path);
            lgData.img = reader.ReadBytes((int)fileInfo.Length);
            MessageBox.Show("Done Selected image :)");
        }
    }
}
