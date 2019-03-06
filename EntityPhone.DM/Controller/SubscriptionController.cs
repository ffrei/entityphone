﻿using System;
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
            DateTime end_date
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
                    end_date = end_date
                };
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
                foreach (ISubscription subscription in context.subscription.ToList())
                {
                    res.Add(subscription);
                }
                return res;
            }
        }

        public ISubscription GetById(int id)
        {
            using (var context = new EPEntities())
            {
                return context.subscription.Find(id);
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
                context.subscription.Remove((subscription)subscription);
                context.SaveChanges();
            }
        }

    }
}
