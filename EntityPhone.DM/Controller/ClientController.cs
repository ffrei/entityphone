using System;
using System.Collections.Generic;
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
                foreach (IClient client in context.client.ToList())
                {
                    res.Add(client);
                }
                return res;
            }
        }
    }
}
