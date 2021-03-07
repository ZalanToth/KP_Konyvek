using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvescucc
{
    class Members
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string PostalCode { get; set; }
        public string PlaceOfResidence { get; set; }
        public string Street { get; set; }

        public Members(string row)
        {
            try
            {
                string[] dx = row.Split(';');
                MemberID = int.Parse(dx[0]);
                Name = dx[1];
                BirthDate = dx[2];
                PostalCode = dx[3];
                PlaceOfResidence = dx[4];
                Street = dx[5];
            }
            catch(Exception)
            {
                return;
            }
        }
    }
}
