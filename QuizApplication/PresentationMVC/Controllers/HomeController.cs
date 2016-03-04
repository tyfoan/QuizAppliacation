using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using PresentationMVC.Models.ViewModels;
using System.Collections.Generic;
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

#pragma warning disable 618
        public ActionResult Index()
        {
            Mapper.CreateMap<ThemeDto, Theme>();
            Mapper.CreateMap<TestDto, Test>();
            Mapper.CreateMap<QuestionDto, Question>();
            Mapper.CreateMap<AnswerDto, Answer>();

            //Mapper.CreateMap<Subject, SubjectDTO>();
            Mapper.CreateMap<SubjectDto, Subject>();
            List<Subject> subjects = Mapper.Map<IEnumerable<SubjectDto>, List<Subject>>(service.GetAll());
            return View(subjects);
        }
#pragma warning restore 618

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