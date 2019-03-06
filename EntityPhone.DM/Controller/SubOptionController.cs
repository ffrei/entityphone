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
    public class SubOptionDAL
    {
        public ISubOption Create(int subscription_id, int option_id, DateTime start_date, DateTime end_date)
        {
            using (var context = new EPEntities())
            {
                sub_option c = new sub_option()
                {
                    subscription_id = subscription_id,
                    option_id = option_id,
                    start_date = start_date,
                    end_date = end_date
                };
                context.sub_option.Add(c);
                context.SaveChanges();
                if (c.sub_option_id > 0)
                {
                    return c;
                }
                return null;
            }
        }

        public List<ISubOption> GetAll()
        {
            using (var context = new EPEntities())
            {
                List<ISubOption> res = new List<ISubOption>();
                foreach (ISubOption subOption in context.sub_option.ToList())
                {
                    res.Add(subOption);
                }
                return res;
            }
        }
        public ISubOption GetById(int id)
        {
            using (var context = new EPEntities())
            {
                return context.sub_option.Find(id);
            }
        }

        public void Update(ISubOption subOption)
        {
            using (var context = new EPEntities())
            {
                context.Entry(subOption).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(ISubOption subOption)
        {
            using (var context = new EPEntities())
            {
                context.Entry(subOption).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
