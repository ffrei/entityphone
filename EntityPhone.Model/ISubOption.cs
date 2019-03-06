using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public abstract class ISubOption
    {
        public int sub_option_id { get; set; }
        public int subscription_id { get; set; }
        public int option_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }
}
