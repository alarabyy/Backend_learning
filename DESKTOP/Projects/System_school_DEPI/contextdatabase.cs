using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace System_school
{
    public class contextdatabase : DbContext 
    {
        //CREATE constractor
        public contextdatabase() : base("firstconection") 
        {
        
        }
        public DbSet<Deparmentt> Deparmentts { get; set; }
        public DbSet<Studentdatabase> Studentts { get; set; }
    }
}
