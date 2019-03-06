using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public class IClient
    {
        public int client_id { get; set; }
        public int seller_id { get; set; }
        public string name { get; set; }
        public DateTime birthday { get; set; }
    }
}
