using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public interface IHistory
    {
        int GetHistoryId();
        void SetHistoryId(int val);
        int GetSubscriptionId();
        void SetSubscriptionId(int val);
        DateTime GetTimestamp();
        void SetTimestamp(DateTime val);
        string GetDestinationNumber();
        void SetDestinationNumber(string val);
        string GetPhoneCode();
        void SetPhoneCode(string val);

    }
}
