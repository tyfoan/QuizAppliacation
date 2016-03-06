using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using UI.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        readonly IBaseQuizService _service;

        public HomeController(IBaseQuizService service)
        {
            this._service = service;
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
            List<Subject> subjects = Mapper.Map<IEnumerable<SubjectDto>, List<Subject>>(_service.GetAll());
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