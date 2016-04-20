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

                cfg.CreateMap<StudentAnswerViewModel, StudentAnswerDto>();
                cfg.CreateMap<StudentAnswerDto, StudentAnswerViewModel>();

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


            foreach (var item in test.Questions)
                if (item != null)
                    item.AnswerVariant = item.Answers.Count(a => a.IsTrue) > 1 ? AnswerVarian.MoreThanOne : AnswerVarian.One;

            return View(test);
        }


        [HttpPost]
        public ActionResult EndTest(TestViewModel test, int userId)
        {
            foreach (var question in test.Questions)
            {
                if (question.ChoosenAnswer)
                {
                    break;

                }
                foreach (var answer in question.Answers)
                {
                    if (answer.IsAnswered)
                    {
                        _service.AddStudentAnswer(new StudentAnswerDto()
                        {
                            StudentAnswerGuid = Guid.NewGuid(),
                            AnswerId = answer.AnswerId,
                            QuestionId = question.QuestionId,
                            UserId = userId
                        });
                    }
                }
            }

            return View(new TestPassViewModel() { Score = 999, Time = new DateTime(1994, 12, 1), Test = test });
        }
    }
}