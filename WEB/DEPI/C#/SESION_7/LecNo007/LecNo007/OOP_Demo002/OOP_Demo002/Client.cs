using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo002
{
    public partial class Client
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public DateTime registerDate { get; set; }
        public string EMial { get; set; }
        partial void MyMethod()// Partial & Private
        {
            System.Windows.Forms.MessageBox.Show("Welcome");
        }
        public void Welcome()
        {
            MyMethod(); // Call Private Method in public ONE=Encapulation
        }
    }
}
