using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityPhone.DM.Model;

namespace EntityPhone.DM.Controller
{
    public class ClientDAL
    {
        public EntityPhone.Model.IClient Create(string name, DateTime birthday)
        {
            using (var context = new EPEntities())
            {
                client c = new client()
                {
                    name = name,
                    birthday = birthday
                };
                context.SaveChanges();
                if(c.client_id > 0)
                {
                    return c;
                }
                return null;
            }
        }
    }
}
