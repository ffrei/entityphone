using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public interface IOption
    {
        int GetOptionId();
        void SetOptionId(int val);
        int GetMinuteLimit();
        void SetMinuteLimit(int val);
        int GetSMSLimit();
        void SetSMSLimit(int val);
        decimal GetPrice();
        void SetPrice(decimal val);
        decimal GetOverageMinutePrice();
        void SetOverageMinutePrice(decimal val);
        decimal GetOverageSMSPrice();
        void SetOverageSMSPrice(decimal val);
        bool GetIsAvailable();
        void SetIsAvailable(bool val);

    }
}
