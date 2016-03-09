using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using UI.Models;
using UI.Models.ViewModels;
using WebMatrix.WebData;

namespace UI.Controllers
{

    [Authorize]
//    [InitializeSimpleMembership]

    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private IMapper _mapper;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, RegisterModel>();
                cfg.CreateMap<RegisterModel, UserDto>();
            });
            _mapper = config.CreateMapper();
        }

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
                    if (!_accountService.IsUserBlocked(model.Email))
                    {

                    if (WebSecurity.Login(model.Email, model.Password, persistCookie: model.RememberMe))
                    {
                        var xda = User.Identity.Name;
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Вы ввели неправильный логин или пароль");
                    return View(model);
                    }
                    else
                        ModelState.AddModelError("", "Аккаунт был заблокирован");
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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel registermodel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registermodel.Email, registermodel.Password,
                        new
                        {
                            FirstName = registermodel.FirstName,
                            LastName = registermodel.LastName,
                            IsBlocked = false,
                        });
                    Roles.AddUserToRole(registermodel.Email, "user");
                    WebSecurity.Login(registermodel.Email, registermodel.Password, false);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View(registermodel);
        }

        [Authorize]
        public ActionResult Manage()
        {
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            RegisterModel user = _mapper.Map<UserDto, RegisterModel>(_accountService.GetDto(userId));
            return View(user);
        }

        [Authorize]
        public ActionResult Edit()
        {
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            RegisterModel user = _mapper.Map<UserDto, RegisterModel>(_accountService.GetDto(userId));
            return View(user);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(RegisterModel registerModel)
        {
            var user = new UserDto();
            user = _mapper.Map<UserDto>(registerModel);
            if (_accountService.Edit(user))
            {
                return RedirectToAction("Manage");
            }
            ModelState.AddModelError("", "Невозможно редактировать данные, что то пошло не так, попытайтесь еще раз");
            return View(registerModel);
        }



        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.ChangePassword(User.Identity.Name, model.oldPassword, model.Password))
                {
                    return RedirectToAction("Manage");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный текущий пароль");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}