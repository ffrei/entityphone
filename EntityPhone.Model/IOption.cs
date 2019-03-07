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
        bool GetIsAvailable();
        void SetIsAvailable(bool val);
        string GetName();
        void SetName(string val);

    }
}
