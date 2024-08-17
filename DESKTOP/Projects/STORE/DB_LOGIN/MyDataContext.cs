using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using STORE.DB_LOGIN;
namespace STORE.DB_LOGIN
{
    
    public class MyDataContext : DbContext
    {
        public MyDataContext() : base("LoginDatabase") 
        { 
        }
        public DbSet<LoginData> LoginDatas { get; set; }
    }
}
