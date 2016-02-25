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
    public class ExamineController : Controller
    {
        IBaseQuizService _service;

        public ExamineController(IBaseQuizService service)
        {
            this._service = service;
        }
        // GET: Examine
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Testing(Guid testId)
        {
            //Mapper.CreateMap<ThemeDTO, Theme>();
            Mapper.CreateMap<TestDTO, Test>();
            Test test = Mapper.Map<TestDTO, Test>(_service.Get(testId));
            List<Question> questions = test.Questions;
            foreach (var item in questions)
            {
                item.AnswerVariant = item.Answers.Count(a => a.IsTrue) > 1 ?  AnswerVarian.MoreThanOne : AnswerVarian.One;
            }

            return View(questions);
        }
        [HttpPost]
        public ActionResult Testing(List<Question> tests)
        {

            return View("EndtTest");
        }
        public ActionResult EndTest()
        {
            return View();
        }
    }
}