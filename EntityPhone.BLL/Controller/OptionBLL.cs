using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityPhone.DM.Controller;
using EntityPhone.Model;


namespace EntityPhone.BLL.Controller
{
    public class OptionBLL
    {

        private OptionDAL optionDAL { get; set; }
        public OptionBLL()
        {
            this.optionDAL = new OptionDAL();
        }
        public IOption Create(string name, int minute_limit, int sms_limit, decimal price, decimal overage_minute_price, decimal overage_sms_price, bool is_available)
        {
            return optionDAL.Create(name, minute_limit, sms_limit, price, overage_minute_price, overage_sms_price, is_available);
        }

        public List<IOption> GetAll()
        {
            return optionDAL.GetAll();
        }

        public IOption GetById(int id)
        {
            return optionDAL.GetById(id);
        }

        public void Update(IOption option)
        {
            optionDAL.Update(option);
        }
        public void Delete(IOption option)
        {
            optionDAL.Delete(option);
        }
    }
}
