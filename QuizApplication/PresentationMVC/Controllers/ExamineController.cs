﻿using AutoMapper;
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

            //List<Question> questions = test.Questions;

            foreach (var item in test.Questions)
                if (item != null)
                    item.AnswerVariant = item.Answers.Count(a => a.IsTrue) > 1 ? AnswerVarian.MoreThanOne : AnswerVarian.One;

            //return View(questions);
            return View(test);
        }


        [HttpPost]
        public ActionResult EndTest(Test test) //questions=null
        {


            int count = test.Questions.Count;


            foreach (var question in test.Questions)
            {
                foreach (var answer in question.Answers)
                {
                    _service.AddStudentAnswer(new StudentAnswerDTO()
                    {
                        StudentAnswerId = Guid.NewGuid(),
                        AnswerId = answer.AnswerId,
                        QuestionId = question.QuestionId,
                        //UserId = User.UserId TODO:Добавить юзера.
                    });
                    if (answer.IsTrue == answer.IsAnswered)
                    {
                        continue;
                    }
                    else
                    {
                        count -= 1;
                        break;
                    }
                }
            }

            TestPass testPass = new TestPass()
            {
                TestPassId = Guid.NewGuid(),
                Test = test,
                Score = count
                //User = Test.User;
            };



            return View(testPass);
        }
    }
}