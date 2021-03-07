using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvescucc
{
    class Books
    {
        public int BookID { get; set; }
        public string Book { get; set; }
        public string Author { get; set; }
        public string ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public bool Rent { get; set; }
        

        public Books(string row)
        {
            try
            {
                string[] xd = row.Split(';');
                BookID =int.Parse( xd[0]);
                Author = xd[1];
                if (Author == "")
                {
                    Author = "";
                }
                ReleaseDate = (xd[3]);
                Book = xd[2];
                Publisher = xd[4];
                Rent =Convert.ToBoolean(xd[5]);
            }
            catch(Exception)
            {
                return;
            }
        }
    }
}
