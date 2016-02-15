using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using PresentationMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationMVC.Controllers
{
    public class HomeController : Controller
    {
        IBaseQuizService service;

        public HomeController(IBaseQuizService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
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
        public ActionResult Test()
        {
            Mapper.CreateMap<SubjectDTO, Subject>();
            List<Subject> subjects = Mapper.Map<IEnumerable<SubjectDTO>, List<Subject>>(service.GetAll());
            return View(subjects);
        }
    }
}