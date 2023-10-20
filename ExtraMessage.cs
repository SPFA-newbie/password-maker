using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordMaker
{
    internal class ExtraMessage
    {
        public string name { get; set; }
        public string message { get; set; }
        public int length { get; set; }
        public bool digit { get; set; }
        public bool lowercase { get; set; }
        public bool capital { get; set; }
        public bool symbol { get; set; }

        public ExtraMessage()
        {
            name = message = "";
            length = 1;
            digit = lowercase = capital = symbol = false;
        }
    }
}
