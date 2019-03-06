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
        private ClientDAL clientDAL { get; set; }

        public ClientBLL()
        {
            this.clientDAL = new ClientDAL();
        }

        public IClient Create(string name, DateTime birthday)
        {
            if(birthday.Date == DateTime.Today)
            {
                Console.WriteLine("Happy Birthday");
            }
            return clientDAL.Create(name, birthday);
        }

        public List<IClient> GetAll()
        {
            return clientDAL.GetAll();
        }


        public IClient GetById(int id)
        {
            return clientDAL.GetById(id);
        }

        public IClient GetByPhoneNumber(string phone_number)
        {
            return clientDAL.GetByPhoneNumber(phone_number);
        }

        public void Update(IClient client)
        {
            clientDAL.Update(client);
        }

        public void Delete(IClient client)
        {
            clientDAL.Delete(client);
        }
    }
}
