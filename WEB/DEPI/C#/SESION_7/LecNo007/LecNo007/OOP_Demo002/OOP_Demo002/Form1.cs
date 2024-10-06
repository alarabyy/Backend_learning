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

namespace OOP_Demo002
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client c1 = new Client();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order.TaxRate = .14;
            Order.Damgha = 100;
            Order o1 = new Order() 
            { OrderID=101,UnitPrice=50,Quantity=3};
            Order o2 = new Order()
            { OrderID = 102, UnitPrice = 100, Quantity = 3  };
            lblTotal.Text = o1.OrderTotal() + "\n" + o2.OrderTotal(); ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order.Damgha = 300;
            lblTotal.Text = Order.Damgha.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string src = "";
            string dest = "";
            File.Copy(src, dest);
            File.Delete(src);
            FileStream fs = new FileStream("", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            //reader.rea
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x = 50;
            x.Increment(10);
            Employee e1 = new Employee();
            e1.AddEmployee();
            CEO c1 = new CEO();
            c1.koko();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string name = "Mohamed";
            name.MyEncrypt(""); // Extended Method
            Encryption.Encrypt(name, ""); // Static Method
        }
    }
}
