using System.Web.Mvc;
using System.Web.Security;
using UI.Models;
using WebMatrix.WebData;

namespace UI.Controllers
{

    [Authorize]
//    [InitializeSimpleMembership]

    public class AccountController : Controller
    {
        //private IAccountService _accountservice;
        //private IMapper _mapper;

        //public AccountController(IAccountService acc)
        //{
        //    _accountservice = acc;
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<UserDto, RegisterModel>();
        //        cfg.CreateMap<RegisterModel, UserDto>();
        //    });
        //    _mapper = config.CreateMapper();
        //}

        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {

                if (WebSecurity.UserExists(model.Email))
                {
                    //if (!accountservice.IsUserBlocked(model.Login))
                    //{
                    var x = Membership.GetUser("Admin@mail.ru");
                    var y = Membership.GetUser(model.Email);
                    //var dd = x.IsApproved;

                    if (WebSecurity.Login(model.Email, model.Password, persistCookie: model.RememberMe))
                    {
                        var xda = User.Identity.Name;
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Вы ввели неправильный логин или пароль");
                    //    return System.Web.UI.WebControls.View(model);
                    //}
                    //else
                    //    ModelState.AddModelError("", "Аккаунт был заблокирован");
                }
                else
                    ModelState.AddModelError("", "Такого аккаунта не существует");
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}