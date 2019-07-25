using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_homework1.Controllers
{
    public class ValidController : Controller
    {
        // GET: Valid
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RemarkCheck(string remark)
        {
            bool isValidate = remark.Length <=100;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}