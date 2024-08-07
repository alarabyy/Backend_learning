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
        public Students(DateTime birthdate)
        {
            this.birthdate = birthdate;
        }
        //===============================================================
        //===============================================================
        //===============================================================
        //===============================================================
        private int age { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        private string Fullname { get; set; }
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

        //===============================================================
        //===============================================================
        //===============================================================
        //join date geather than 6 years
        public bool IsJoinDateValid()
        {
            DateTime minJoinDate = birthdate.AddYears(6);

            return Joindate >= minJoinDate;
        }
        //===============================================================
        //===============================================================
        //===============================================================

        private byte[] GetPicture()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            return this.Picture  = GetPicture();
        }
            //===============================================================
            //===============================================================
            //===============================================================

            //get  birth day
            private int Getage()
        {
            var age = (DateTime.Now - birthdate).TotalDays /365;
            
            return Convert.ToInt32(age);
        }
        //get full name
        private string Getfullname(string Fullname)
        {

            string full = Firstname + " " + Lastname;

            return this.Fullname = Fullname;
        }
        //===================================================================================
        //===================================================================================
        //===================================================================================
        //===================================================================================
        //===================================================================================
        public double Total(double[] marks)
        {
            int sum = 0;
            foreach (int mark in marks)
            {
                sum += mark;
            }
            return sum;
        }


        public void Report()
        {
             
        }


    }
}
