using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvescucc
{
    class Rents
    {
        public int RentID { get; set; }
        public int RMemberID { get; set; }
        public int RBookID { get; set; }
        public string StartOfRent{ get; set; }
        public string EndOfRent { get; set; }

        public Rents(string row)
        {
            try
            {
                string[] dd = row.Split(';');
                RentID = int.Parse(dd[0]);
                RMemberID = int.Parse(dd[1]);
                RBookID = int.Parse(dd[2]);
                StartOfRent = dd[3];
                EndOfRent = dd[4];
            }
            catch (Exception)
            {
                return;
            }

        }
    }
}
