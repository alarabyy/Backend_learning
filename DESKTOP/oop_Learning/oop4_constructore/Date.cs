using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop4_constructore
{
    public class Date
    {                                          //0,1 ,2 ,3 ,4 ,5 ,6 ,7 ,8 ,9,10,11 ,12
        private static readonly int[] year365 = {0,31,28,31,30,31,30,31,31,30,31,30,31 };
        private static readonly int[] year366 = {0,31,29,31,30,31,30,31,31,30,31,30,31 };
        public int day;
        public int month;
        public int year;

        public Date(int day, int month, int year)
        {
            var  isseld = year %4 ==0;
            if (month>=1 && month <=12 && year >=1 && year<=999)
            {
                int[] d = isseld ? year366 : year365; 
                if(day >= 1 && day <= d[month]) 
                {
                    this.day = day;
                    this.month = month;
                    this.year = year;
                }
                else
                {
                    this.day = 01;
                    this.month = 01;
                    this.year = 01;
                }
            }
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public string getdate()
        {
            return $"{this.day.ToString().PadLeft(2, '0')} /" +
                $"{this.month.ToString().PadLeft(3, '0')} /" +
                $"{this.year.ToString().PadLeft(4, '0')}";
        }
    }

}
