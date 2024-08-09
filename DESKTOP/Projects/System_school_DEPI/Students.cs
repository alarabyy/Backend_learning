using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_System_school
{
    public class Students
    {
        //default consrtactor
        public Students()
        {
        }
        //first name and last args consrtactor
        public Students(string firstname , string lastname) 
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
        //birthdate args consrtactor
    
        public Students(string firstname, string lastname, DateTime birthdate, string studentnumber)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.birthdate = birthdate;
            this.studentnumber = studentnumber;
        }
        //===============================================================
        //===============================================================
        //===============================================================
        //===============================================================
        private string Fullname { get; set; }
        private int age { get; set; }
        public string studentnumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime Joindate { get; set; }
        public string Classname { get; set; }
        public string Grades { get; set; }
        public string Level { get; set; }
        public double[] Marks { get; set; }
        public Byte[] Picture { get; set; }
        public string Picturepath { get; set; }
        public int Studentnumbers { get; set; }
        public int Traininghourse { get; set; }
        //===============================================================

        private string GetFullName()
        {
            return Fullname = Firstname +"-"+ Lastname;
        }
  
        //calc birth day
        private DateTime BirthDate
        {
            get { return birthdate; }
            set
            {
                DateTime now = DateTime.Now;
                TimeSpan timeSpan = now - birthdate;
                Convert.ToInt32(timeSpan.TotalDays);
            }
        }
        //calc join  date
        public DateTime JoinDate
        {
            get { return Joindate; }
            set
            {
                if (value >= birthdate.AddYears(6))
                {
                    Joindate = value;
                }
                else
                {
                    throw new ArgumentException("JoinDate must be at least 6 years after BirthDate.");
                }
            }
        }
        //===================================================================================

        public virtual double Total()
        {
            if (Marks == null || Marks.Length == 0)
            {
                return 0;
            }
            double total = 0;
            foreach (double mark in Marks)
            {
                total += mark;
            }
            return total;
        }
        //===================================================================================

        public virtual double Percentage()
        {
            if (Marks == null || Marks.Length == 0)
            {
                return 0;
            }
            return (Total() / Marks.Length) * 100;
        }
        //===================================================================================

        public virtual string Report()
        { 
            return $"Student: {GetFullName()}\n" +
                   $"studentnumber:{studentnumber}\n"+
                   $"Grade Level: {Grades}\n" +
                   $"birthdate: {birthdate}\n" +
                   $"Join Date: {Joindate.ToShortDateString()}\n" +
                   $"age: {birthdate}\n"  ; 
        }

                //===================================================================================

        //===============================================================
        //===============================================================
        //===============================================================
        public enum Grade
        {
            grade1=1,
            grade2,
            grade3,
            grade4,
            grade5,
            grade6,
            grade7,
            grade8,
            grade9,
            grade10
        }

       
 
        //===================================================================================
        //===================================================================================
        //===================================================================================
        //===================================================================================
        //===================================================================================
    




    }
}
