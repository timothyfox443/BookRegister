using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister
{
    class Registration
    {
        public int CustomerID { get; set; }
        public string ISBN { get; set; }
        public DateTime RegDate { get; set; }

        public string GetRegistrationDisplay(string seperator)
        {
            return $"{CustomerID}{seperator}{ISBN}{seperator}{RegDate}";
        }
    }
}
