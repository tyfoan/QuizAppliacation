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
                if (item != null)
                    item.AnswerVariant = item.Answers.Count(a => a.IsTrue) > 1 ? AnswerVarian.MoreThanOne : AnswerVarian.One;

            return View(questions);
        }


        [HttpPost]
        public ActionResult EndTest(List<Question> questions) //questions=null
        {
            TestPass testPass = new TestPass();

            int count = questions.Count;

            foreach (var question in questions)
            {
                foreach (var answer in question.Answers)
                {
                    _service.AddStudentAnswer(new StudentAnswerDTO()
                    {
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
            testPass.Score = count;
            testPass.Time = DateTime.Now; //Время прохождения.
            
            

            return View(testPass);
        }
    }
}