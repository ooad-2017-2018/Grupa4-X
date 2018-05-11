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
        private static int GLOBAL_ID = 0;
        private int id;
        private string username;
        private SecureString lozinka;
        public Administrator(string username, SecureString lozinka)
        {
            this.Username = username;
            this.Lozinka = lozinka;
            Id = GLOBAL_ID++;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

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

        public SecureString Lozinka
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

        
    }
}
