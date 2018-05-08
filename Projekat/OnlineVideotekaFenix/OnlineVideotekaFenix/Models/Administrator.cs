using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVideotekaFenix.Models
{
    public class Administrator
    {
        private static int GLOBAL_ID = 0;
        private int id;
        private string naziv;
        private string lozinka;
        public Administrator(string naziv, string lozinka)
        {
            this.Naziv = naziv;
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

        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
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

        
    }
}
