using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IAccountService _accountService;
        private IMapper _mapper;


        public AdminController(IAccountService accountService)
        {
            _accountService = accountService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, UserDto>();
                cfg.CreateMap<UserDto, UserViewModel>();
            });
            _mapper = config.CreateMapper();
        }

        public ActionResult TableUsers()
        {
            var users = _mapper.Map<IEnumerable<UserDto>, List<UserViewModel>>(_accountService.GetUsers());
            

            return View(users);
        }

        [HttpGet]
        public ActionResult IsBlocked(int id)
        {
            if (_accountService.BlockingUser(id))
            {
                return PartialView("_BlockButton", id);
            }
            else
            {
                return PartialView("_UnblockButton", id);
            }
            
        }
    }
}