using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORE.DB_LOGIN
{
    public class LoginData
    {

  [Key] public int loginID { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public byte[] img { get; set; }
    }
}
