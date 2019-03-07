using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public interface IClient : IValidatableObject
    {
        int GetClientId();
        void SetClientId(int val);
        int GetSellerId();
        void SetSellerId(int val);
        string GetName();
        void SetName(string val);
        DateTime GetBirthday();
        void SetBirthDay(DateTime val);
    }
}
