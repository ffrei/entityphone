using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityPhone.DM.Controller;
using EntityPhone.Model;

namespace EntityPhone.BLL.Controller
{
    public class SubcriptionBLL
    {
        private SubscriptionDAL subscriptionDAL { get; set; }

        public SubcriptionBLL()
        {
            this.subscriptionDAL = new SubscriptionDAL();
        }

        public ISubscription Create(int plan_id,
            int client_id,
            string phone_number,
            DateTime start_date,
            DateTime end_date)
        {
            return subscriptionDAL.Create(plan_id, client_id, phone_number, start_date, end_date);
        }

        public List<ISubscription> GetAll()
        {
            return subscriptionDAL.GetAll();
        }


        public ISubscription GetById(int id)
        {
            return subscriptionDAL.GetById(id);
        }

        public void Update(ISubscription subscription)
        {
            subscriptionDAL.Update(subscription);
        }

        public void Delete(ISubscription subscription)
        {
            subscriptionDAL.Delete(subscription);
        }
    }
}
