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
    public class PlanDAL
    {
        public IPlan Create(string name, int minute_limit, int sms_limit, decimal price, decimal overage_minute_price, decimal overage_sms_price, bool is_available)
        {
            using (var context = new EPEntities())
            {
                plan c = new plan()
                {
                    name = name,
                    minute_limit = minute_limit,
                    sms_limit = sms_limit,
                    price = price,
                    overage_minute_price = overage_minute_price,
                    overage_sms_price = overage_sms_price,
                    is_available = is_available
                };
                context.plan.Add(c);
                context.SaveChanges();
                if (c.plan_id > 0)
                {
                    return c;
                }
                return null;
            }
        }

        public List<IPlan> GetAll()
        {
            using (var context = new EPEntities())
            {
                List<IPlan> res = new List<IPlan>();
                foreach (IPlan plan in context.plan.ToList())
                {
                    res.Add(plan);
                }
                return res;
            }
        }
        public IPlan GetById(int id)
        {
            using (var context = new EPEntities())
            {
                return context.plan.Find(id);
            }
        }

        public void Update(IPlan plan)
        {
            using (var context= new EPEntities())
            {
                context.Entry(plan).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete (IPlan plan)
        {
            using (var context = new EPEntities())
            {
                context.Entry(plan).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
