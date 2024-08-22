using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo002
{
    public static class Extentions
    {
        // Create Extentions Methods
        public static int Increment(this int value,int incrementer)
        {
            return value + incrementer;
        }
        public static void AddEmployee(this Employee emp)
        {
            System.Windows.Forms.MessageBox.Show("Extented for Emp");
        }
    }
}
