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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace STORE
{
    public partial class HOMEPAGE : Form
    {

        public HOMEPAGE()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private int userID;

        public HOMEPAGE(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }
        private void HOMEPAGE_Load(object sender, EventArgs e)
        {
            MyDataContext database2 = new MyDataContext();

            var query = from LoginDatas in database2.LoginDatas
                        where LoginDatas.loginID == userID 
                        select new
                        {
                            LoginDatas.phone,
                            LoginDatas.email,
                            LoginDatas.username,
                            LoginDatas.img
                        };

            var result = query.FirstOrDefault();
            if (result != null)
            {
                byte[] img = result.img;
                string name = result.username;
                string email = result.email;
                string phone = result.phone;

                 Bitmap image = new Bitmap(new MemoryStream(img));

                txtname.Text = name;
                txtemail.Text = email;
                txtphone.Text = phone;
                pictureBox1.Image = image;
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
