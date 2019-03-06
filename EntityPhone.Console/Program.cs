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
            System.Console.WriteLine("Create Client");
            ClientBLL clientBLL = new ClientBLL();
            IClient clientThomas = clientBLL.Create("Thomas", new DateTime(1980, 3, 25));

            System.Console.WriteLine("Create Plan");
            PlanBLL planBLL = new PlanBLL();
            IPlan planNoSMS = planBLL.Create("No SMS", -1, 0, 15, 0, 0.15M, true);

            System.Console.WriteLine("Create Subscription");
            SubscriptionBLL subscriptionBLL = new SubscriptionBLL();
            ISubscription subscriptionThomas = subscriptionBLL.Create(
                planNoSMS.GetPlanId(),
                clientThomas.GetClientId(),
                "06234235262",
                DateTime.Now,
                null);

            String phoneNumber = subscriptionThomas.GetPhoneNumber();
            System.Console.WriteLine("Searching client by phone number : "+ phoneNumber);
            IClient clientThomas2 = clientBLL.GetByPhoneNumber(phoneNumber);

            if (clientThomas2 != null)
            {
                System.Console.WriteLine("client Thomas found by phone number : " + clientThomas2.GetClientId());
            }
            else
            {
                System.Console.WriteLine("client not found");
            }

            System.Console.WriteLine("Update phone number");
            subscriptionThomas.SetPhoneNumber("0623425262");
            subscriptionBLL.Update(subscriptionThomas);

            System.Console.WriteLine();
            System.Console.WriteLine("List all clients");
            foreach (IClient client in clientBLL.GetAll())
            {
                System.Console.WriteLine(client.GetName() +
                    " id " + client.GetClientId() +
                    " borne on " + client.GetBirthday().ToShortDateString());
            }

            System.Console.WriteLine();
            System.Console.WriteLine("List all plans");
            foreach (IPlan plan in planBLL.GetAll())
            {
                System.Console.WriteLine(plan.GetName() +
                    " id " + plan.GetPlanId());
            }

            System.Console.WriteLine();
            System.Console.WriteLine("List all subscriptions");
            foreach (ISubscription subscription in subscriptionBLL.GetAll())
            {
                System.Console.WriteLine(subscription.GetPhoneNumber() +
                    " id " + subscription.GetSubscriptionId());
            }

            
            subscriptionBLL.Delete(subscriptionThomas);
            clientBLL.Delete(clientThomas);
            planBLL.Delete(planNoSMS);
            

            System.Console.Read();
        }
    }
}
