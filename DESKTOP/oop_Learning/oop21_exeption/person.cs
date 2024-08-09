using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop21_exeption
{
    public class person
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public person(string name)
        {
            ////////////////////if (name.Trim() == "") throw new Exception("eror404");   //first test
            if (name == "") throw new my_exception();

            _name = name;
        }
        public void printname()
        {
            Console.WriteLine(_name);
        }


    }
}
