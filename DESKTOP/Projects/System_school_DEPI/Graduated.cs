using System;

namespace System_school
{

    public class Graduated : Students
    {
        public int CreditHours { get; set; }
        public string ProjectType { get; set; }

        public  DateTime JoinDate
        {
            get { return base.JoinDate; }
            set
            {
                if (value >= Birthdate.AddYears(18))
                {
                    base.JoinDate = value;
                }
                else
                {
                    throw new ArgumentException("JoinDate must be at least 18 years after BirthDate.");
                }
            }
        }

        // Override TrainingHours property
        public new int Traininghours
        {
            get { return base.Traininghours; }
            set
            {
                if (value >= 100)
                {
                    base.Traininghours = value;
                }
                else
                {
                    throw new ArgumentException("TrainingHours must be at least 100.");
                }
            }
        }

        // Override Report() method
        public override string Report()
        {
            return base.Report() +
                   $"Credit Hours: {CreditHours}\n" +
                   $"Project Type: {ProjectType}\n";
        }
    }
}
