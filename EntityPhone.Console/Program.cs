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
            System.Console.WriteLine("Creating some SMS and Call History");
            List<IHistory> Histories = new List<IHistory>();

            HistoryBLL historyBLL = new HistoryBLL();
            for (int i = 0; i < 5; i++)
            {
                ISMSHistory history = historyBLL.CreateSMS(subscriptionThomas.GetClientId(), DateTime.Now, "605040302", "+33");
                ICallHistory call = historyBLL.CreateVoice(subscriptionThomas.GetClientId(), DateTime.Now, "605040343", "+33", 35);
                Thread.Sleep(1000);
                Histories.Add(history);
                Histories.Add(call);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("List all history");

            foreach (IHistory histor in historyBLL.GetAll())
            {
                if (histor is ICallHistory)
                {
                    System.Console.WriteLine("Phone call : " + histor.GetTimestamp()
                        + " FROM : " + subscriptionBLL.GetById(histor.GetSubscriptionId()).GetPhoneNumber()
                        + " TO : " + histor.GetDestinationNumber()
                        + " DURING  : " + ((ICallHistory)histor).GetDuration() + " Seconds");
                }
                else
                {
                    System.Console.WriteLine("SMS : " + histor.GetTimestamp()
                        + " FROM : " + subscriptionBLL.GetById(histor.GetSubscriptionId()).GetPhoneNumber()
                        + " TO : " + histor.GetDestinationNumber());

                }
                historyBLL.Delete(histor);

            }

            System.Console.WriteLine();
            System.Console.WriteLine("Creating some options");
            OptionBLL optionBLL = new OptionBLL();
            IOption option = optionBLL.Create("SMSBooster", 0, 100, 10, false);

            System.Console.WriteLine();
            System.Console.WriteLine("List all options");
            foreach (IOption opt in optionBLL.GetAll())
            {
                System.Console.WriteLine("Option : " + opt.GetName()
                    + " minute limit : " + opt.GetMinuteLimit()
                    + " sms limit : " + opt.GetSMSLimit()
                    + " price : " + opt.GetPrice()
                    + " is available : " + opt.GetIsAvailable());
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Creating SubOption");
            SubOptionBLL subOptionBLL = new SubOptionBLL();
            ISubOption subOption = subOptionBLL.Create(subscriptionThomas.GetSubscriptionId(), option.GetOptionId(), DateTime.Today, DateTime.Today.AddDays(10));

            System.Console.WriteLine();
            System.Console.WriteLine("Listing SubOptions");

            foreach (ISubOption opt in subOptionBLL.GetAll())
            {
                System.Console.WriteLine("SubOption subscriptor : " + subscriptionBLL.GetById(opt.GetSubscriptionId()).GetPhoneNumber()
                    + " for option : " + optionBLL.GetById(opt.GetOptionId()).GetName()
                    + " Started on : " + opt.GetStartDate()
                    + " Ending on : " + opt.GetEndDate());
            }

            subOptionBLL.Delete(subOption);
            optionBLL.Delete(option);
            subscriptionBLL.Delete(subscriptionThomas);
            clientBLL.Delete(clientThomas);
            planBLL.Delete(planNoSMS);


            System.Console.Read();
        }
    }
}
