using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.BLL.Utils
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string name, string data): base(ModifyMessage(name, data))
        {
        }

        private static string ModifyMessage(string name, string data)
        {
            return "Wrong format :" + data + " does not correspond to " + name + " format";
        }
    }
}
