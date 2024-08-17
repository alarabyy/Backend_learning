using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STORE.DB_LOGIN;
namespace STORE
{

    public partial class login : Form
    {
        MyDataContext database = new MyDataContext();

        public login()
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
            string enteredEmail = textBox1.Text;
            string enteredPassword = textBox2.Text;

            //CHECK  AUTHENTECKATION
            var user = database.LoginDatas.
                FirstOrDefault(u => u.email == enteredEmail && u.password == enteredPassword);

            if (user != null)
            {

                MessageBox.Show("Login done :)", "sucssefull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HOMEPAGE hOMEPAGE = new HOMEPAGE(user.loginID);
                this.Hide();
                hOMEPAGE.ShowDialog();
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
            }
            else
            {
                MessageBox.Show(" EROR IN DATA :)", "NOT sucssefull!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
            }
        }
    }
}
