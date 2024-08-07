using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace create_form7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            //frm.ShowDialog();
            TextBox txt = new TextBox();
            Button button = new Button();
            Label lbl = new Label();
            frm.Controls.Add(txt);
            frm.Controls.Add(button);
            frm.Controls.Add(lbl);
            button.Location = new Point(200, 200);
            lbl.Location = new Point(250, 250);
            lbl.Text = " welcome in new form";
            

            //---------------------------------------------------------
            frm.StartPosition = FormStartPosition.CenterScreen ;
            frm.Size = new Size(500, 500);

            //---------------------------------------------------------
            frm.Show();
        }
    }
}
