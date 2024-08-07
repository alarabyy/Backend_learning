using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_printeinovice
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

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://alarabyy.github.io/14_my_portfolio/");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {



            textBox2.Text = DateTime.Now.ToString("yyyy/MM/dd");


            Dictionary<int, string> data = new Dictionary<int, string>();
            data.Add(10000, "laptop_hp");
            data.Add(15000, "laptop_dell");
            data.Add(12000, "printer_hp");
            data.Add(1700, "printer_lenovo");
            data.Add(19000, "printer_dell");
            data.Add(1860, "scanner_lenovo");
            data.Add(11000, "scanner_hp");
            data.Add(11400, "scanner_dell");
            data.Add(12120, "computer_lenovo");
            data.Add(1230, "computer_hp");
            data.Add(12025, "computer_dell");
            data.Add(1225, "ipad_lenovo");
            data.Add(1250, "ipad_hp");
            data.Add(12680, "ipad_dell");

            comboBox.DataSource = new BindingSource(data, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            txtprice.Text = comboBox.SelectedValue.ToString();



            foreach(DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.ForeColor = Color.DarkBlue;
                col.DefaultCellStyle.BackColor = Color.Bisque;
            }
            dataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[3].DefaultCellStyle.ForeColor = Color.DarkGreen;

            txtname.Focus();
            txtname.Select();
            txtname.SelectAll();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
              comboBox.Focus();
            }

        }

        private void comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtquntity.Focus();
                txtquntity.SelectAll();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(comboBox.SelectedIndex <= -1)return ;

            string items = comboBox.Text;
            int qunt = Convert.ToInt32(txtquntity.Text);
            int price = Convert.ToInt32(txtprice.Text);
            int total = qunt * price;

            object[] rows = { items ,qunt ,price ,total};
            dataGridView1.Rows.Add(rows);
            txttotal.Text = Convert.ToInt32(txttotal.Text)+total +" " ;


            MessageBox.Show("add..!","ok!",MessageBoxButtons.OKCancel,MessageBoxIcon.Hand,MessageBoxDefaultButton.Button3);
        }

        private void quntity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnadd.PerformClick();
                txtname.Focus();
            }

        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtprice.Text = comboBox.SelectedValue.ToString();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnadd.PerformClick();
                txtname.Focus();
            }
        }
    }
}
