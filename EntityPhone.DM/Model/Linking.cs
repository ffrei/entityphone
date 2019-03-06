using EntityPhone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.DM.Model
{
    public partial class client : IClient { }
    public partial class history : IHistory { }
    public partial class call_history : ICallHistory
    {
        public int GetHistoryId()
        {
            return this.history_id;
        }

        public void SetHistoryId(int val)
        {
            this.history_id = val;
        }

        public int GetDuration()
        {
            return this.duration;
        }

        public void SetDuration(int val)
        {
            this.duration = val;
        }
    }
    public partial class option : IOption { }
    public partial class plan : IPlan { }
    public partial class sms_history : ISMSHistory
    {
        public int GetHistoryId()
        {
            return this.history_id;
        }

        public void SetHistoryId(int val)
        {
            this.history_id = val;
        }
    }

    public partial class sub_option : ISubOption { }
    public partial class subscription : ISubscription { }



}
