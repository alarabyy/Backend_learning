using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop22_xml
{
    /// <summary>
    /// the main generator class
    /// </summary>
    /// <remarks>
    /// generate ran_id and rand_pass
    /// </remarks>
    public class Generator
    {
        ///<value> this is  last_id</value>
        public static int lastid { get; private set; } = 1;

        /// <summary>
        /// ganrateid  
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="hiredate"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string ganrateid(string fname ,string lname , DateTime? hiredate)
        {
            if (fname == null)
                throw new InvalidOperationException(($"can`t be null:{nameof(fname)}"));
            if (lname == null)
                throw new InvalidOperationException(($"can`t be null{ nameof(fname)}"));

            if(hiredate == null)
            {
                hiredate = DateTime.Now;
            }
            else
            {
                if(hiredate.Value.Date < DateTime.Now.Date) { }
                throw new InvalidOperationException(($"can`t be null{nameof(hiredate)}"));

            }
            var yy = hiredate.Value.ToString("yy");
            var mm = hiredate.Value.ToString("mm");
            var dd = hiredate.Value.ToString("dd");

            var code = $"{fname.ToUpper()[0]}{lname.ToUpper()[0]}{yy}{mm}{dd}{(lastid++).ToString().PadLeft(2, '0')}";

            return code;
        
        }

        public static string ganraterandonpass(int length)
        {
            const string validscope = "sdnksldgjm;klrr32132131dfgergiufhdbjknfgegerg";
            var result = "";
            Random ran = new Random();

            while ( 0 < length--)
            {
                result += (validscope[ran.Next(validscope.Length)]);
            }
            return result;
        }
    }
}
