using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityPhone.DM.Controller;
using EntityPhone.Model;

namespace EntityPhone.BLL.Controller
{
    public class PlanBLL
    {
        private PlanDAL planDAL { get; set; }
        public PlanBLL()
        {
            this.planDAL = new PlanDAL();
        }
        public IPlan Create(string name, int minute_limit, int sms_limit, decimal price, decimal overage_minute_price, decimal overage_sms_price, bool is_available)
        {
            return planDAL.Create(name, minute_limit, sms_limit, price, overage_minute_price, overage_sms_price, is_available);
        }

        public List<IPlan> GetAll()
        {
            return planDAL.GetAll();
        }

        public IPlan GetById(int id)
        {
            return planDAL.GetById(id);
        }

        public void Update(IPlan plan)
        {
            planDAL.Update(plan);
        }
        public void Delete(IPlan plan)
        {
            planDAL.Delete(plan);
        }

    }
}
