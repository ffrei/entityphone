using EntityPhone.BLL.Controller;
using EntityPhone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            System.Console.WriteLine("Searching client by phone number : " + phoneNumber);
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


            System.Console.WriteLine();
            System.Console.WriteLine("Create an History");
            List<IHistory> Histories = new List<IHistory>();

            HistoryBLL historyBLL = new HistoryBLL();

            string[] phone_nums = {"(1) (415) 123-1234",
                                    "(415) 123-1234",
                                    "1-800-123-1234",
                                    "206/782-8410",
                                    "206.782.8410",
                                    "05324225543",
                                    "+335324225543",
                                    "206 782 8410 ",
                                    "206-782-8410",
                                    "(206) 782-8410",
                                    "555-555-5555"};

            foreach(string phone_num in phone_nums)
            {
                ISMSHistory history = historyBLL.CreateSMS(subscriptionThomas.GetClientId(), DateTime.Now, phone_num, "+33");
                Thread.Sleep(1000);
                Histories.Add(history as IHistory);
            }

            try
            {
                ISMSHistory history = historyBLL.CreateSMS(subscriptionThomas.GetClientId(), DateTime.Now, "05324+343", "+33");
                historyBLL.Delete(history as IHistory);
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("List all history");

            foreach (IHistory histor in Histories)
            {

                System.Console.WriteLine(histor.GetTimestamp() + " FROM : " + subscriptionThomas.GetPhoneNumber() + " TO : " + histor.GetDestinationNumber());
                historyBLL.Delete(histor as IHistory);

            }


            subscriptionBLL.Delete(subscriptionThomas);
            clientBLL.Delete(clientThomas);
            planBLL.Delete(planNoSMS);


            System.Console.Read();
        }
    }
}
