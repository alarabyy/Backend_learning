using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace System_school
{
    public class Studentdatabase
    {
        [Key]
        public int StudentId { get; set; }
        public string Fullname { get; set; }
        public int Studentcode { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime Joindate { get; set; }
        public string Grade { get; set; }
        public string nameimg { get; set; }
        public byte[] img {  get; set; }

    }
    public class Deparmentt : Studentdatabase
    {
        [Key]
        public int Deparmentid { get; set; }
        public ICollection<Studentdatabase> students { get; set; }

    }
}
