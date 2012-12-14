using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace net.tkglaser.demos.Controllers
{
    public class SpinnerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            Thread.Sleep(5000);

            return View();
        }
    }
}
