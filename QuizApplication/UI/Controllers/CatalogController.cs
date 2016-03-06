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
            Mapper.CreateMap<ThemeDto, Theme>();

            Mapper.CreateMap<TestDto, Test>();
            Mapper.CreateMap<QuestionDto, Question>();
            Mapper.CreateMap<AnswerDto, Answer>();

            //Mapper.CreateMap<Subject, SubjectDTO>();
            Mapper.CreateMap<SubjectDto, Subject>();
            List<Subject> subjects = Mapper.Map<IEnumerable<SubjectDto>, List<Subject>>(_service.GetAll());
            return View(subjects);
        }


        public ActionResult AboutTest(Guid testId)
        {
            Mapper.CreateMap<ThemeDto, Theme>();
            Mapper.CreateMap<TestDto, Test>();
            Test test = Mapper.Map<TestDto, Test>(_service.Get(testId));
            return View(test);
        }
#pragma warning restore 618

    }
}