using net.tkglaser.demos.Models.Phone;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net.tkglaser.demos.Controllers
{
    public class PhoneValidationController : Controller
    {
        public ActionResult EnterDetails()
        {
            return View(new DetailsModel());
        }

        [HttpPost]
        public ActionResult EnterDetails(DetailsModel model)
        {
            try
            {
                PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                PhoneNumber n = phoneUtil.Parse(model.Phone, "GB");

                model.PhoneNumberFormatted = phoneUtil.Format(n, PhoneNumberFormat.INTERNATIONAL);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Phone", e.Message);
            }
            return View(model);
        }
    }
}
