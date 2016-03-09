using System.Net;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class AnswersController : Controller
    {
        private IAnswerService _answerService;
        private ISubjectService _subjectService;
        private IMapper _mapper;

        public AnswersController(IAnswerService answerService, ISubjectService subjectService)
        {
            _answerService = answerService;
            _subjectService = subjectService;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnswerViewModel, AnswerDto>();
                cfg.CreateMap<AnswerDto, AnswerViewModel>();

                cfg.CreateMap<QuestionViewModel, QuestionDto>();
                cfg.CreateMap<QuestionDto, QuestionViewModel>();

                cfg.CreateMap<SubjectViewModel, SubjectDto>();
                cfg.CreateMap<SubjectDto, SubjectViewModel>();
            });
            _mapper = config.CreateMapper();
        }



        // GET: Answers/Create
        public ActionResult Create(int questionId)
        {
            var model = new AnswerViewModel();
            model.QuestionId = questionId;
            return View(model);
        }

        // POST: Answers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnswerViewModel answer, int? questionId)  // [Bind(Include = "AnswerId,Name,Complexity,Rate,Duration,IsApproved")]
        {
            if (ModelState.IsValid)
            {
                AnswerDto answerDto = _mapper.Map<AnswerViewModel, AnswerDto>(answer);
                _answerService.AddAnswer(answerDto);
                return RedirectToAction("Details", "Questions", new { id = answer.QuestionId });
            }
            return View(answer);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AnswerDto answer = _answerService.GetAnswer(id.Value);
            AnswerViewModel answerVewModel = _mapper.Map<AnswerDto, AnswerViewModel>(answer);

            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answerVewModel);
        }

        // POST: Answers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnswerViewModel answer, int? questionId)
        {
            if (ModelState.IsValid)
            {
                AnswerDto answerDto = _mapper.Map<AnswerViewModel, AnswerDto>(answer);
                _answerService.EditAnswer(answerDto);
                return RedirectToAction("Details", "Questions", new { id = answer.QuestionId});

            }
            return View(answer);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id, int? questionId)
        {
            _answerService.DeleteAnswer(id.Value);
            return RedirectToAction("Details", "Questions", new { id = questionId });

        }
    }
}
