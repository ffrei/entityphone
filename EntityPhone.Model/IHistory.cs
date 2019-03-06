using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public abstract class IHistory
    {
        public int history_id { get; set; }
        public int subscription_id { get; set; }
        public DateTime timestamp { get; set; }
        public string destination_number { get; set; }
        public string phone_code { get; set; }
    }
}
