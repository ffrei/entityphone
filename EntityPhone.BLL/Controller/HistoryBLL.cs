using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityPhone.DM.Controller;
using EntityPhone.Model;

namespace EntityPhone.BLL.Controller
{
    public class HistoryBLL
    {
        private HistoryDAL historyDAL { get; set; }
        public HistoryBLL()
        {
            this.historyDAL = new HistoryDAL();
        }
        public IHistory CreateSMS(int subscription_id, DateTime timestamp, string destination_number, string phone_code)
        {
            return historyDAL.CreateSMS(subscription_id, timestamp, destination_number, phone_code);
        }

        public IHistory CreateVoice(int subscription_id, DateTime timestamp, string destination_number, string phone_code, int duration)
        {
            return historyDAL.CreateVoice(subscription_id, timestamp, destination_number, phone_code,duration);
        }

        public List<IHistory> GetAll()
        {
            return historyDAL.GetAll();
        }

        public IHistory GetById(int id)
        {
            return historyDAL.GetById(id);
        }

        public void Update(IHistory history)
        {
            historyDAL.Update(history);
        }
        public void Delete(IHistory history)
        {
            historyDAL.Delete(history);
        }
    }
}
