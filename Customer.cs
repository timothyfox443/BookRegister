using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister
{
    class Customer
    {
        public int CustomerID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Appelation { get; set; }

        public string GetCustomerDisplay ( string seperator)
        {
            return $"{CustomerID}{seperator}{DateOfBirth}{seperator}"+
                    $"{FirstName}{seperator}{LastName}{seperator}{Appelation}";

        }

        public override string ToString()
        {
            string name = $"{FirstName} {LastName}";
            return name;
        }
    }
}
