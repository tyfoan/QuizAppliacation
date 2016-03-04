using System.Web.Mvc;

namespace PresentationMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Manage()
        {
            return View();
        }
    }
}