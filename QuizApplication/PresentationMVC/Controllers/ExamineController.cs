using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationMVC.Controllers
{
    public class ExamineController : Controller
    {
        // GET: Examine
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Testing(Guid testId)
        {
            return View();
        }

        public ActionResult EndTest()
        {
            return View();
        }
    }
}