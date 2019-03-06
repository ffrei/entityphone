using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Model
{
    public interface ISMSHistory
    {
        int GetHistoryId();
        void SetHistoryId(int val);
    }
}
