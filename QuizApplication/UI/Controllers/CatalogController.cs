using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        readonly IBaseQuizService _service;

        public CatalogController(IBaseQuizService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }
#pragma warning disable 618

        public ActionResult List()
        {
            Mapper.CreateMap<ThemeDto, ThemeViewModel>();

            Mapper.CreateMap<TestDto, TestViewModel>();
            Mapper.CreateMap<QuestionDto, QuestionViewModel>();
            Mapper.CreateMap<AnswerDto, AnswerViewModel>();

            //Mapper.CreateMap<Subject, SubjectDTO>();
            Mapper.CreateMap<SubjectDto, SubjectViewModel>();
            List<SubjectViewModel> subjects = Mapper.Map<IEnumerable<SubjectDto>, List<SubjectViewModel>>(_service.GetAll());
            return View(subjects);
        }


        public ActionResult AboutTest(int testId)
        {
            Mapper.CreateMap<ThemeDto, ThemeViewModel>();
            Mapper.CreateMap<TestDto, TestViewModel>();
            TestViewModel test = Mapper.Map<TestDto, TestViewModel>(_service.Get(testId));
            return View(test);
        }
#pragma warning restore 618

    }
}