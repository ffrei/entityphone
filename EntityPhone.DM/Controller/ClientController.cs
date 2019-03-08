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

    public class ClientDAL
    {
        public IClient Create(string name, DateTime birthday)
        {
            using (var context = new EPEntities())
            {
                client c = new client()
                {
                    name = name,
                    birthday = birthday
                };
                context.client.Add(c);
                context.SaveChanges();
                if (c.client_id > 0)
                {
                    return c;
                }
                return null;
            }
        }

        public List<IClient> GetAll()
        {
            using (var context = new EPEntities())
            {
                List<IClient> res = new List<IClient>();
                foreach (client client in context.client.ToList())
                {
                    context.Entry(client).Collection(c => c.subscription).Load();
                    res.Add(client);
                }
                return res;
            }
        }

        public IClient GetById(int id) {
            using (var context = new EPEntities())
            {
                client client = context.client.Find(id);
                context.Entry(client).Collection(c => c.subscription).Load();
                return client;
            }
        }

        public IClient GetByPhoneNumber(string phone_number)
        {
            using (var context = new EPEntities())
            {
                client client = context.client.Where(c =>
                    c.subscription.Where(s => s.phone_number == phone_number).FirstOrDefault().client_id == c.client_id).First();

                context.Entry(client).Collection(c => c.subscription).Load();
                return client;
            }
        }

        public void Update(IClient client)
        {
            using (var context = new EPEntities())
            {
                context.Entry((client)client).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(IClient client)
        {
            using (var context = new EPEntities())
            {
                context.Entry((client)client).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
