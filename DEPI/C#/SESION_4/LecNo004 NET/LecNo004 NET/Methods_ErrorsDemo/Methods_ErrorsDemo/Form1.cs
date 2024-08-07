using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Methods_ErrorsDemo
{
    // Create new Types
    public struct Curreny // value Type
    {
        // Properties
        public string CurrencySymbol;
        public int DecimalPalces;
        // Methods
        public void GetCurrency()
        {

        }
    }
   
    public partial class Form1 : Form
    {
        //-------------------------Declaring new Methods
        public string    Report(string employeename,double salary,double taxrate,DateTime HireDate)
        {
            double taxValue = salary * taxrate;
            double Net = salary - taxValue;
            double tms = (DateTime.Now - HireDate).TotalDays / 365;
            return "Employee Name " + employeename + 
                "\n have net salary= " + Net + "\n " +
                "works about " + tms + "year";

        }
        public void Increment(ref int x)
        {
            x++; // Die Here
        }
        public int Increment2(int x)
        {
            x++;
            return x;
        }
        public string NetSalary( //INPUT Paramters
            double salary,double taxrate,double bonusrate,
            //OUTPUT Paramters = MUST Calculated into Body
                out double tax,out double bonus)
        {
            //Must Assign value to out Paramters
             tax = salary * taxrate;
             bonus = salary * bonusrate;
            double net = salary + bonus - tax;
            return net.ToString();
        }
        public double AddValues(double value1,double value2)
        {
            double result = value1 * value2;
            return result;
        }
        //=================================================
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCombo(comboBox1,100,200);
        }

        private void FillCombo(ComboBox combo,int start,int end)
        {
            for (int i = start; i < end; i++)
            {
                combo.Items.Add(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double sal = Convert.ToDouble(txtSalary.Text);
            double tx = Convert.ToDouble(txtTax.Text);
           lblReport.Text= Report(HireDate: dtHire.Value, // ParamterName:Value
                employeename: txtName.Text,
                taxrate: tx, 
                salary: sal);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(txtSalary.Text);
            Increment(ref y);
            lblReport.Text = y.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(txtSalary.Text);
            //Increment2(y);
            lblReport.Text = Increment2(y).ToString(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double tx, boun;
            lblReport.Text = 
                NetSalary(salary: Convert.ToDouble(txtSalary.Text),
                          taxrate: Convert.ToDouble(txtTax.Text),
                          bonusrate: .1,out tx,out boun);
            MessageBox.Show("Tax Value = "+tx +"\n bonus value = "+boun );
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lblReport.Text = AddValues(Convert.ToDouble(txtSalary.Text), Convert.ToDouble(txtTax.Text)).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //Code to Try
                int value1 = Convert.ToInt32(txtNumber1.Text);
                int value2 = Convert.ToInt32(txtNumber2.Text);
                int res = value1 / value2;
                lblResult.Text = res.ToString();
            }
            
            catch (FormatException)
            {
                // When using Text or Left box Empty
                MessageBox.Show("Please enter Valid Values");
                txtNumber1.Focus();
                txtNumber1.BackColor = Color.Beige;
                txtNumber1.Text = txtNumber2.Text = string.Empty;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Can Not Devide by Zero ya ...");
                txtNumber2.BackColor = Color.Orange;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Toooo Large value");
            }
            catch (Exception ex) // General Exception
            {
                MessageBox.Show(ex.Message);
                // MessageBox.Show("An Error Eccured .. please Try Again");
            }
            finally
            {
                MessageBox.Show("Connection Closed");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x, y;
            x = Convert.ToInt32(txtNumber1.Text);
            y = Convert.ToInt32(txtNumber2.Text);
            if (x==y)
            {
                lblCompareResult.Text = "Same value";
            }
            else
            {
                lblCompareResult.Text = "Diff values";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int[] arr = { 10, 20, 30 };
            int[] arr1 = { 10, 20, 30 };
            //arr = arr1;
            if (arr==arr1)
            {
                lblCompareResult.Text = "Same Rerefence";
            }
            else
            {
                
                lblCompareResult.Text = "Not Same Reference";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int x;
           lblCompareResult.Text= int.TryParse(txtNumber1.Text, out x).ToString();
            MessageBox.Show(x.ToString());
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Use Value Type = Use Directly
            int x=50;
            Curreny c;
            c.DecimalPalces = 2;
            c.CurrencySymbol = "$";
            // Reference Type Use = MUST create Object Before use
            MyClass c1 = new MyClass();
            c1.First = 10;
            c1.Get();
        }
    }
}
