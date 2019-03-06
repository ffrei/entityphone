using EntityPhone.BLL.Controller;
using EntityPhone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientBLL clientBLL = new ClientBLL();
            /*IClient client = clientBLL.Create("john", DateTime.Now);
            if(client == null)
            {
                System.Console.WriteLine("client is null");
            }
            else
            {
                System.Console.WriteLine(client.name);
            }*/
            foreach (IClient client in clientBLL.GetAll())
            {
                System.Console.WriteLine("client : " + client.GetName());
            }
            System.Console.Read();
        }
    }
}
