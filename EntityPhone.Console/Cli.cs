using EntityPhone.BLL.Controller;
using EntityPhone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.Console
{
    class Cli
    {
        ClientBLL clientBLL;
        HistoryBLL historyBLL;
        OptionBLL optionBLL;
        PlanBLL planBLL;
        SubOptionBLL subOptionBLL;
        SubscriptionBLL subscriptionBLL;

        public Cli()
        {
            clientBLL = new ClientBLL();
            historyBLL = new HistoryBLL();
            optionBLL = new OptionBLL();
            planBLL = new PlanBLL();
            subOptionBLL = new SubOptionBLL();
            subscriptionBLL = new SubscriptionBLL();
        }
        
        public void start()
        {
            bool end = false;
            string line;
            while (!end)
            {
                System.Console.WriteLine("What do you wanna do ? (list, show, quit)");
                line = System.Console.ReadLine();
                switch (line)
                {
                    case "list":
                        list_start();
                        break;
                    case "show":
                        show_start();
                        break;
                    case "quit":
                        end = true;
                        System.Console.WriteLine("Exiting");
                        break;
                    default:
                        System.Console.WriteLine("Try again : list, show, quit");
                        break;
                }
            }
        }

        private void client()
        {
            System.Console.WriteLine("plop");
        }

        private void show_start()
        {
            bool end = false;
            string line;
            while (!end)
            {
                System.Console.WriteLine("What do you wanna do ? (plan, option, client, back)");
                line = System.Console.ReadLine();
                switch (line)
                {
                    case "plan":
                        show_plan();
                        break;
                    case "option":
                        show_option();
                        break;
                    case "client":
                        show_client();
                        break;
                    case "back":
                        end = true;
                        break;
                    default:
                        System.Console.WriteLine("Try again : plan, option, back");
                        break;
                }
            }
        }

        private void show_option()
        {
            System.Console.WriteLine("Enter option id");
            IOption option = null;
            while (option == null)
            {
                string line = System.Console.ReadLine();
                try
                {
                    option = optionBLL.GetById(int.Parse(line));
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                if (option != null)
                {
                    string res = "option : " + option.GetName() + "(" + option.GetOptionId() + ")" +
                        "\nPrice : " + option.GetPrice() + "€" +
                        "\nLimits : \n    minute : " + option.GetMinuteLimit() +
                        "\n    sms : " + option.GetSMSLimit();
                    if (option.GetIsAvailable())
                    {
                        res += "\nIs available";
                    }
                    else
                    {
                        res += "\nIsn't available";
                    }
                    System.Console.WriteLine(res);
                }
            }
        }

        private void show_plan()
        {
            System.Console.WriteLine("Enter plan id");
            IPlan plan = null;
            while(plan == null)
            {
                string line = System.Console.ReadLine();
                try
                {
                    plan = planBLL.GetById(int.Parse(line));
                }catch(Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                if(plan != null)
                {
                    string res = "Plan : " + plan.GetName() + "(" + plan.GetPlanId() + ")" +
                        "\nPrice : " + plan.GetPrice() + "€" +
                        "\n" + "Limits : \n    minute : " + plan.GetMinuteLimit() + " then " + plan.GetOverageMinutePrice() + "€/min" +
                        "\n    sms : " + plan.GetSMSLimit() + " then " + plan.GetOverageSMSPrice() + "€/sms";
                    if (plan.GetIsAvailable())
                    {
                        res += "\nIs available";
                    }
                    else
                    {
                        res += "\nIsn't available";
                    }
                    System.Console.WriteLine(res); 
                }
            }
        }

        private void show_client()
        {
            System.Console.WriteLine("Enter client id");
            IClient client = null;
            while (client == null)
            {
                string line = System.Console.ReadLine();
                try
                {
                    client = clientBLL.GetById(int.Parse(line));
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                if (client != null)
                {
                    string res = "client : " + client.GetName() + "(" + client.GetClientId() + ")" +
                        "\nBirthday :" + client.GetBirthday().ToShortDateString();

                    list_subscription(client);


                    System.Console.WriteLine(res);
                    this.client();
                }
            }
        }

        private void list_subscription(IClient client)
        {
            foreach(ISubscription subscription in client.GetSubscription())
            {
                System.Console.WriteLine("    -" + subscription.GetSubscriptionId() + " : " + subscription.GetPhoneNumber());
            }
        }

        private void list_start()
        {
            bool end = false;
            string line;
            while (!end)
            {
                System.Console.WriteLine("What do you wanna list ? (client, plan, option, back)");
                line = System.Console.ReadLine();
                switch (line)
                {
                    case "client":
                        list_clients();
                        end = true;
                        break;
                    case "plan":
                        list_plans();
                        end = true;
                        break;
                    case "option":
                        list_options();
                        end = true;
                        break;
                    case "back":
                        end = true;
                        break;
                    default:
                        System.Console.WriteLine("Try again : client, plan, option, back");
                        break;
                }
            }
        }

        private void list_options()
        {
            foreach (IOption option in optionBLL.GetAll())
            {
                System.Console.WriteLine("    -" + option.GetOptionId() + " : " + option.GetName());
            }
        }

        private void list_plans()
        {
            foreach (IPlan plan in planBLL.GetAll())
            {
                System.Console.WriteLine("    -" + plan.GetPlanId() + " : " + plan.GetName());
            }
        }

        private void list_clients()
        {
            foreach (IClient client in clientBLL.GetAll())
            {
                System.Console.WriteLine("    -" + client.GetClientId() + " : " + client.GetName());
            }
        }

        static void Main(string[] args)
        {
            Cli cli = new Cli();
            cli.start();
        }
    }
}
