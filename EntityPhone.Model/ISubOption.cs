using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public interface ISubOption : IValidatableObject
    {
        int GetSubOptionId();
        void SetSubOptionId(int val);
        int GetSubscriptionId();
        void SetSubscriptionId(int val);
        int GetOptionId();
        void SetOptionId(int val);
        DateTime GetStartDate();
        void SetStartDate(DateTime val);
        DateTime? GetEndDate();
        void SetEndDate(DateTime val);
    }
}
