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
    public class CatalogController : Controller
    {
        // GET: Catalog
        IBaseQuizService service;

          public CatalogController(IBaseQuizService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            Mapper.CreateMap<ThemeDTO, Theme>();
            Mapper.CreateMap<TestDTO, Test>();
            Mapper.CreateMap<QuestionDTO, Question>();
            Mapper.CreateMap<AnswerDTO, Answer>();

            //Mapper.CreateMap<Subject, SubjectDTO>();
            Mapper.CreateMap<SubjectDTO, Subject>();
            List<Subject> subjects = Mapper.Map<IEnumerable<SubjectDTO>, List<Subject>>(service.GetAll());
            return View(subjects);
        }

        
        public ActionResult AboutTest(Guid testId)
        {
            Mapper.CreateMap<ThemeDTO, Theme>();
            Mapper.CreateMap<TestDTO, Test>();
            Test test = Mapper.Map<TestDTO, Test>(service.Get(testId));
            return View(test);
        }
    }
}