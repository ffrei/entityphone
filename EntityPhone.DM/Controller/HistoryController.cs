using EntityPhone.DM.Model;
using EntityPhone.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.DM.Controller
{
    public class HistoryDAL
    {
        public ISMSHistory CreateSMS(int subscription_id, DateTime timestamp, string destination_number, string phone_code)
        {
            using (var context = new EPEntities())
            {
                sms_history c = new sms_history()
                {
                    subscription_id=subscription_id,
                    timestamp = timestamp,
                    destination_number = destination_number,
                    phone_code = phone_code
                };
                context.history.Add(c);
                context.SaveChanges();
                if (c.history_id > 0)
                {
                    return c;
                }
                return null;
            }
        }
        public ICallHistory CreateVoice(int subscription_id, DateTime timestamp, string destination_number, string phone_code, int duration)
        {
            using (var context = new EPEntities())
            {
                call_history c = new call_history()
                {
                    subscription_id = subscription_id,
                    timestamp = timestamp,
                    destination_number = destination_number,
                    phone_code = phone_code,
                    duration= duration
                };
                context.history.Add(c);
                context.SaveChanges();
                if (c.history_id > 0)
                {
                    return c;
                }
                return null;
            }
        }

        public List<IHistory> GetAll()
        {
            using (var context = new EPEntities())
            {
                List<IHistory> res = new List<IHistory>();
                foreach (IHistory history in context.history.ToList())
                {
                    res.Add(history);
                }
                return res;
            }
        }
        public IHistory GetById(int id)
        {
            using (var context = new EPEntities())
            {
                return context.history.Find(id);
            }
        }

        public void Update(IHistory history)
        {
            using (var context = new EPEntities())
            {
                context.Entry(history).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(IHistory history)
        {
            using (var context = new EPEntities())
            {
                context.Entry(history).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
