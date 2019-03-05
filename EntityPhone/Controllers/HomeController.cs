using System;
using System.Collections.Generic;
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
                /* var plan = new plan()
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
                var query = context.plan.ToList();
                foreach(var plan in query)
                {
                    sb.AppendLine(plan.name);
                    log.Info(plan.name);
                }
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