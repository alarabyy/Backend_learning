using System;
using System.Windows.Forms;

namespace System_school
{
    public class Students
    {
        // Events
        public event EventHandler OnFinalYear;
        public event EventHandler OnNextGrad;

        // Default constructor
        public Students()
        {
        }

        // Constructor with first name and last name
        public Students(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        // Full constructor
        public Students(string firstname, string lastname, DateTime birthdate, string studentnumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            Birthdate = birthdate;
            Studentnumber = studentnumber;
        }

        // Private properties
        private string Fullname
        {
            get { return $"{Firstname} - {Lastname}"; }
        }

        private int Age
        {
            get
            {
                int age = DateTime.Now.Year - Birthdate.Year;
                if (DateTime.Now < Birthdate.AddYears(age))
                {
                    age--;
                }
                return age;
            }
        }

        // Public properties
        public string Studentnumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual DateTime JoinDate
        {
            get { return Joindate; }
            set
            {
                if (value >= Birthdate.AddYears(6))
                {
                    Joindate = value;
                }
                else
                {
                    MessageBox.Show("JoinDate must be at least 6 years after BirthDate.");
                }
            }
        }
        public DateTime Joindate { get; private set; }
        public string Classname { get; set; }
        public Grade Grades { get; set; }
        public string Level { get; set; }
        public double[] Marks { get; set; }
        public byte[] Picture { get; set; }
        public string Picturepath { get; set; }
        public int Traininghours { get; set; }

        // Calculate total marks
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

        // Calculate percentage
        public virtual double Percentage()
        {
            if (Marks == null || Marks.Length == 0)
            {
                return 0;
            }
            return (Total() / Marks.Length) * 100;
        }

        // Generate report
        public virtual string Report()
        {
            return $"Student: {Fullname}\n" +
                   $"Student Number: {Studentnumber}\n" +
                   $"Grade Level: {Grades}\n" +
                   $"Birthdate: {Birthdate.ToShortDateString()}\n" +
                   $"Join Date: {Joindate.ToShortDateString()}\n" +
                   $"Age: {Age}\n";
        }

        // Check if the student is in final year and trigger event
        public virtual void CheckFinalYear()
        {
            if (Grades == Grade.Grade12)
            {
                OnFinalYear?.Invoke(this, EventArgs.Empty);
            }
        }

        // Check if the percentage is over 50 and trigger event
        public virtual void CheckGrade()
        {
            if (Percentage() > 50)
            {
                OnNextGrad?.Invoke(this, EventArgs.Empty);
            }
        }

        // Enumeration for grade levels
        public enum Grade
        {
            Grade1 = 1,
            Grade2,
            Grade3,
            Grade4,
            Grade5,
            Grade6,
            Grade7,
            Grade8,
            Grade9,
            Grade10,
            Grade11,
            Grade12
        }
    }
}
