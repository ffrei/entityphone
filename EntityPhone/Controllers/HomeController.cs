using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EntityPhone.Models;
using log4net;

namespace EntityPhone.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult Index()
        {
            StringBuilder sb = new StringBuilder();
            using(var context = new appEntities())
            {
                context.plan.Load();

                // Add a new plan to the context
                context.plan.Add(new plan
                {
                    name = "BasicTests",
                    minute_limit = 100,
                    sms_limit = 110,
                    price = 10,
                    overage_minute_price = 0.014M,
                    overage_sms_price = 0.15M,
                    is_available = true

                });

                context.plan.Find(2).name = "testmodified";
                // Mark one of the existing plans as Deleted
                context.plan.Remove(context.plan.Find(1));

                // Loop over the plans in the context.
                log.Info("In Local: ");
                foreach (var plan in context.plan.Local)
                {
                    log.Info(
                        "Plan ID : " +
                        plan.plan_id + " Plan Name : " +
                        plan.name + "Context state : " +
                        context.Entry(plan).State);
                }

                // Perform a query against the database.
                log.Info("\nIn DbSet query: ");
                foreach (var plan in context.plan)
                {
                    log.Info(
                        "Plan ID : " +
                        plan.plan_id+ " Plan Name : "+
                        plan.name+ "Context state : "+
                        context.Entry(plan).State);
                }

                log.Info("\nAll modified entities: ");
                foreach (var entry in context.ChangeTracker.Entries()
                                          .Where(e => e.State == EntityState.Modified))
                {
                    log.Info(
                        "Found entity of type "+ ObjectContext.GetObjectType(entry.Entity.GetType()).Name+" with state "+ entry.State
                        );
                }                /* var plan = new plan()
                 {
                     name = "Basic",
                     minute_limit = 100,
                     sms_limit = 110,
                     price = 10,
                     overage_minute_price = 0.014M,
                     overage_sms_price = 0.15M,
                     is_available = true

                 };
                 context.plan.Add(plan);
                 context.SaveChanges();*/
                                 //  var query = context.plan.Find(1).name;//context.plan.ToList();
                                 // log.Error(query);

            }
            
            return View((object)sb.ToString());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}