using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public interface IPlan : IValidatableObject
    {
        int GetPlanId();
        void SetPlanId(int val);
        string GetName();
        void SetName(string val);
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
        IList<ISubscription> GetSubscriptions();
    }
}
