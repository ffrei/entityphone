using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public interface ICallHistory
    {
        int GetHistoryId();
        void SetHistoryId(int val);
        int GetDuration();
        void SetDuration(int val);
    }
}
