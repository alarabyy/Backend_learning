using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo002
{
    public class Order
    {
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public static double TaxRate { get; set; }
        public static double Damgha { get; set; }
        public double Tax()
        {
            return UnitPrice * TaxRate;
        }
        public double NetPrice()
        {
            return UnitPrice+Tax();
        }
        public  double OrderTotal()
        {
            return NetPrice() * Quantity;
        }
        public static void PaymentMassage( string name)
        {
            System.Windows.Forms.MessageBox.Show("welcome"+name + Damgha);
        }
    }
}
