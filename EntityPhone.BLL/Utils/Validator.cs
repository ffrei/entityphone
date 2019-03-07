using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityPhone.BLL.Utils
{
    class Validator
    {
        public static string cleanPhoneNumber(string phone_number, string code)
        {
            return Regex.Replace(Regex.Replace(phone_number, "^\\" + code, "0"), "[ \\.\\-/\\(\\)]", "");
        }
    }
}
