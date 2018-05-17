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



        private string username;
        private string lozinka;
        private string Id;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Lozinka
        {
            get
            {
                return lozinka;
            }

            set
            {
                lozinka = value;
            }
        }

        public string id
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public Administrator(string username,string lozinka,string id = null)
        {
            this.Username = username;
            this.Lozinka = lozinka;
            this.id = id.ToString();
        }

        



    }
}
