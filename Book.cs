using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister
{
    class Book
    {
        #region Properties for Book
        public string ISBN { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        #endregion

        public string GetBokDisplay (string seperator)
        {
            return $"{ISBN}{seperator}{Price}{seperator}{Title}";
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
