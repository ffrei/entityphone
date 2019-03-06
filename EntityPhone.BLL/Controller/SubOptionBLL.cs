using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityPhone.DM.Controller;
using EntityPhone.Model;

namespace EntityPhone.BLL.Controller
{
    public class SubOptionBLL
    {
        private SubOptionDAL sub_optionDAL { get; set; }
        public SubOptionBLL()
        {
            this.sub_optionDAL = new SubOptionDAL();
        }
        public ISubOption Create(int subscription_id, int option_id, DateTime start_date, DateTime end_date)
        {
            return sub_optionDAL.Create(subscription_id, option_id, start_date, end_date);
        }


        public List<ISubOption> GetAll()
        {
            return sub_optionDAL.GetAll();
        }

        public ISubOption GetById(int id)
        {
            return sub_optionDAL.GetById(id);
        }

        public void Update(ISubOption sub_option)
        {
            sub_optionDAL.Update(sub_option);
        }
        public void Delete(ISubOption sub_option)
        {
            sub_optionDAL.Delete(sub_option);
        }
    }
}
