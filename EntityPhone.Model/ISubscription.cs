using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public abstract class ISubscription
    {
        public int subscription_id { get; set; }
        public int plan_id { get; set; }
        public int client_id { get; set; }
        public string phone_number { get; set; }
        public DateTime start_date { get; set; }
        public string end_date { get; set; }
    }
}
