using EntityPhone.BLL.Controller;
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
            clientBLL.Create("john", DateTime.Now);
        }
    }
}
