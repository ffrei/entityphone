using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public interface ICallHistory : IHistory, IValidatableObject
    {
        int GetDuration();
        void SetDuration(int val);
    }
}
