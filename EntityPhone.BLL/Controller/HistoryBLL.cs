using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EntityPhone.BLL.Utils;
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
        public ISMSHistory CreateSMS(int subscription_id, DateTime timestamp, string destination_number, string phone_code)
        {
            return historyDAL.CreateSMS(
                subscription_id,
                timestamp,
                Validator.cleanPhoneNumber(destination_number, phone_code),
                phone_code
                );
        }

        public ICallHistory CreateVoice(int subscription_id, DateTime timestamp, string destination_number, string phone_code, int duration)
        {
            return historyDAL.CreateVoice(
                subscription_id,
                timestamp,
                Validator.cleanPhoneNumber(destination_number, phone_code),
                phone_code,
                duration);
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
            // checking that phone number is correctly written
            history.SetDestinationNumber(Validator.cleanPhoneNumber(
                history.GetDestinationNumber(),
                history.GetPhoneCode()
                ));
            historyDAL.Update(history);
        }
        public void Delete(IHistory history)
        {
            historyDAL.Delete(history);
        }
    }
}
