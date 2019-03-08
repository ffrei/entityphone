using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public interface ISubscription : IValidatableObject
    {
        int GetSubscriptionId();
        void SetSubscriptionId(int val);
        int GetPlanId();
        void SetPlanId(int val);
        int GetClientId();
        void SetClientId(int val);
        string GetPhoneNumber();
        void SetPhoneNumber(string val);
        DateTime GetStartDate();
        void SetStartDate(DateTime val);
        DateTime? GetEndDate();
        void SetEndDate(DateTime val);
        IPlan GetPlan();
        IClient GetClient();
        IList<ISubOption> GetSubOptions();
        IList<IHistory> GetHistories();
    }
}
