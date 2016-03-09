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
        private readonly IBaseQuizService _service;
        private readonly IMapper _mapper;

        public ExamineController(IBaseQuizService service)
        {
            _service = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnswerViewModel, AnswerDto>();
                cfg.CreateMap<AnswerDto, AnswerViewModel>();

                cfg.CreateMap<QuestionViewModel, QuestionDto>();
                cfg.CreateMap<QuestionDto, QuestionViewModel>();

                cfg.CreateMap<TestViewModel, TestDto>();
                cfg.CreateMap<TestDto, TestViewModel>();

                cfg.CreateMap<SubjectViewModel, SubjectDto>();
                cfg.CreateMap<SubjectDto, SubjectViewModel>();
            });
            _mapper = config.CreateMapper();

        }
        // GET: Examine
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Testing(int testId)
        {
            TestViewModel test = _mapper.Map<TestDto, TestViewModel>(_service.Get(testId));
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