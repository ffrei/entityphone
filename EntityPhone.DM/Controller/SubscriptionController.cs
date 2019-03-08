using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityPhone.DM.Model;
using EntityPhone.Model;

namespace EntityPhone.DM.Controller
{
    public class SubscriptionDAL
    {
        public ISubscription Create(
            int plan_id,
            int client_id,
            string phone_number,
            DateTime start_date,
            DateTime? end_date
            )
        {
            using (var context = new EPEntities())
            {
                subscription s = new subscription()
                {
                    plan_id = plan_id,
                    client_id = client_id,
                    phone_number = phone_number,
                    start_date = start_date,
                };
                if (end_date != null)
                {
                    s.end_date = (DateTime)end_date;
                }
                context.subscription.Add(s);
                context.SaveChanges();
                if (s.subscription_id > 0)
                {
                    return s;
                }
                return null;
            }
        }

        public List<ISubscription> GetAll()
        {
            using (var context = new EPEntities())
            {
                List<ISubscription> res = new List<ISubscription>();
                foreach (subscription subscription in context.subscription.ToList())
                {
                    context.Entry(subscription).Collection(c => c.history).Load();
                    context.Entry(subscription).Collection(c => c.sub_option).Load();
                    context.Entry(subscription).Reference(c => c.client).Load();
                    context.Entry(subscription).Reference(c => c.plan).Load();
                    res.Add(subscription);
                }
                return res;
            }
        }

        public ISubscription GetById(int id)
        {
            using (var context = new EPEntities())
            {
                subscription subscription = context.subscription.Find(id);
                context.Entry(subscription).Collection(c => c.history).Load();
                context.Entry(subscription).Collection(c => c.sub_option).Load();
                context.Entry(subscription).Reference(c => c.client).Load();
                context.Entry(subscription).Reference(c => c.plan).Load();
                return subscription;
            }
        }

        public void Update(ISubscription subscription)
        {
            using (var context = new EPEntities())
            {
                context.Entry((subscription)subscription).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(ISubscription subscription)
        {
            using (var context = new EPEntities())
            {
                //context.subscription.Remove((subscription)subscription);
                context.Entry((subscription)subscription).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
