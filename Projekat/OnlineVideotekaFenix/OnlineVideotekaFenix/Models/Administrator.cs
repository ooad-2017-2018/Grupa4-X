using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVideotekaFenix.Models
{
    public class Administrator
    {
        

            
        public string Username { get; set; }
        public string Lozinka { get; set; }

        public string id { get; set; }

        public Administrator(string username,string lozinka,string id = null)
        {
            this.Username = username;
            this.Lozinka = lozinka;
            this.id = id.ToString();
        }

        



    }
}
