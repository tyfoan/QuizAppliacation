using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using UI.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        readonly IBaseQuizService _service;

        public HomeController(IBaseQuizService service)
        {
            _service = service;
        }

#pragma warning disable 618

        public ActionResult Index()
        {
            Mapper.CreateMap<ThemeDto, ThemeViewModel>();
            Mapper.CreateMap<TestDto, TestViewModel>();
            Mapper.CreateMap<QuestionDto, QuestionViewModel>();
            Mapper.CreateMap<AnswerDto, AnswerViewModel>();

            //Mapper.CreateMap<Subject, SubjectDTO>();
            Mapper.CreateMap<SubjectDto, SubjectViewModel>();
            List<SubjectViewModel> subjects = Mapper.Map<IEnumerable<SubjectDto>, List<SubjectViewModel>>(_service.GetAll().Take(3));
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