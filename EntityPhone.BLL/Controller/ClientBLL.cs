using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityPhone.DM.Controller;
using EntityPhone.Model;

namespace EntityPhone.BLL.Controller
{
    public class ClientBLL
    {
        public IClient Create(string name, DateTime birthday)
        {
            ClientDAL clientDAL = new ClientDAL();
            if(birthday.Date == DateTime.Today)
            {
                Console.WriteLine("Happy Birthday");
            }
            return clientDAL.Create(name, birthday);
        }

        public List<IClient> GetAll()
        {
            ClientDAL clientDAL = new ClientDAL();
            return clientDAL.GetAll();
        }
    }
}
