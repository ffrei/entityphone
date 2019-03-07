using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public ISMSHistory CreateSMS(int subscription_id, DateTime timestamp, string destination_number, string phone_code)
        {
            return historyDAL.CreateSMS(
                subscription_id,
                timestamp,
                cleanPhoneNumber(destination_number, phone_code),
                phone_code
                );
        }

        public ICallHistory CreateVoice(int subscription_id, DateTime timestamp, string destination_number, string phone_code, int duration)
        {
            return historyDAL.CreateVoice(
                subscription_id,
                timestamp,
                cleanPhoneNumber(destination_number, phone_code),
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
            history.SetDestinationNumber(cleanPhoneNumber(
                history.GetDestinationNumber(), 
                history.GetPhoneCode()
                ));
            historyDAL.Update(history);
        }
        public void Delete(IHistory history)
        {
            historyDAL.Delete(history);
        }

        private string cleanPhoneNumber(string number, string code)
        {
            string new_number = Regex.Replace(Regex.Replace(number, "^\\" + code, "0"), "[ \\.\\-/\\(\\)]", "");

            if (Regex.IsMatch(new_number, "^\\d{1,12}$"))
                return new_number;
            throw new Exception("Invalid format");
        }
    }
}
