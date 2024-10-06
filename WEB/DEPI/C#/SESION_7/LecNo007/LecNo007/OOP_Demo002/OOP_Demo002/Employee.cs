using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo002
{
    public class Employee
    {

        // Constructor
        public Employee()
        {

        }
        public Employee(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }
        public Employee(string first, double sal)
        {
            this.FirstName = first;
            this.Salary = sal;
        }
        // Define Properties
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public   double Salary { get; set; }
        public virtual double Bonus { get; set; }
        public double TaxRate { get; set; }
        public string FullName { get { return GetFullName(); } }// Read Only Property
        public int Age { get { return GetAge(); } }
        // Define Class Methods
        private string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        private int GetAge()
        {
            var ag = Convert.ToInt32((DateTime.Now - BirthDate).TotalDays / 365);
            return ag;
        }

        protected virtual int TOS()
        {
            var ts = Convert.ToInt32((DateTime.Now - HireDate).TotalDays / 365);
            return ts;
        }
        protected double Tax() // will appear in child
        {
            return Salary * TaxRate;
        }
        protected virtual double BonusValue()
        {
            return 100;
        }
        public virtual double NetSalary()
        {
            return Salary - Tax() + BonusValue();
        }
        public virtual string Report()
        {
            return "EmployeeName: " + FullName + "\n is" + Age + " years old \n have net salary " + NetSalary();
        }
    }
}
