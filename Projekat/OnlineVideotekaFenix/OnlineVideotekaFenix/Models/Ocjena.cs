using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVideotekaFenix.Models
{
    public class Ocjena
    {
        private static int GLOBAL_ID = 0;
        private int id;
        private double ocjenaBroj;

        public Ocjena(double ocjena)
        {
            this.OcjenaBroj = ocjena;
            id = GLOBAL_ID++;
        }

        public int Id
        {
            get
            {
                return id;
            }           
        }

        public double OcjenaBroj
        {
            get
            {
                return ocjenaBroj;
            }

            set
            {
                ocjenaBroj = value;
            }
        } 



    }
}
