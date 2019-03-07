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
    public class OptionDAL
    {
        public IOption Create(string name, int minute_limit, int sms_limit, decimal price, bool is_available)
        {
            using (var context = new EPEntities())
            {
                option c = new option()
                {
                    name = name,
                    minute_limit = minute_limit,
                    sms_limit = sms_limit,
                    price = price,
                    is_available = is_available
                };
                context.option.Add(c);
                context.SaveChanges();
                if (c.option_id > 0)
                {
                    return c;
                }
                return null;
            }
        }

        public List<IOption> GetAll()
        {
            using (var context = new EPEntities())
            {
                List<IOption> res = new List<IOption>();
                foreach (IOption option in context.option.ToList())
                {
                    res.Add(option);
                }
                return res;
            }
        }
        public IOption GetById(int id)
        {
            using (var context = new EPEntities())
            {
                return context.option.Find(id);
            }
        }

        public void Update(IOption option)
        {
            using (var context = new EPEntities())
            {
                context.Entry(option).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(IOption option)
        {
            using (var context = new EPEntities())
            {
                context.Entry(option).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
