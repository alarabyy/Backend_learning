using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STORE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login form2 = new login();
            this.Hide();
            form2.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SIGNIN sIGNIN = new SIGNIN();
            this.Hide();
            sIGNIN.ShowDialog();
        }
    }
}
