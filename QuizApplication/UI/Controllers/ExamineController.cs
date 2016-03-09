using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using UI.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ExamineController : Controller
    {
        readonly IBaseQuizService _service;

        public ExamineController(IBaseQuizService service)
        {
            _service = service;
        }
        // GET: Examine
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Testing(int testId)
        {
            //Mapper.CreateMap<ThemeDTO, Theme>();
#pragma warning disable 618
            Mapper.CreateMap<TestDto, TestViewModel>();
            TestViewModel test = Mapper.Map<TestDto, TestViewModel>(_service.Get(testId));
#pragma warning restore 618
            //List<Question> questions = test.Questions;

            foreach (var item in test.Questions)
                if (item != null)
                    item.AnswerVariant = item.Answers.Count(a => a.IsTrue) > 1 ? AnswerVarian.MoreThanOne : AnswerVarian.One;

            //return View(questions);
            return View(test);
        }


        [HttpPost]
        public ActionResult EndTest(TestViewModel test) //questions=null
        {
            int count = test.Questions.Count;

            foreach (var question in test.Questions)
            {
                foreach (var answer in question.Answers)
                {
                    _service.AddStudentAnswer(new StudentAnswerDto()
                    {
                        AnswerId = answer.AnswerId,
                        QuestionId = question.QuestionId,
                        //UserId = User.UserId TODO:Добавить юзера.
                    });
                    if (answer.IsTrue == answer.IsAnswered)
                    { }
                    else
                    {
                        count -= 1;
                        break;
                    }
                }
            }

            TestPassViewModel testPass = new TestPassViewModel()
            {
                Test = test,
                Score = count
                //User = Test.User;
            };



            return View(testPass);
        }
    }
}