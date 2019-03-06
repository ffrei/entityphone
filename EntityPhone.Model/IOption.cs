using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public abstract class IOption
    {
        public int option_id { get; set; }
        public int minute_limit { get; set; }
        public int sms_limit { get; set; }
        public decimal price { get; set; }
        public decimal overage_minute_price { get; set; }
        public decimal overage_sms_price { get; set; }
        public bool is_available { get; set; }
    }
}
