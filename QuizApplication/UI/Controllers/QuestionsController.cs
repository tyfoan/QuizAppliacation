using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class QuestionsController : Controller
    {
        private IQuestionService _questionService;
        private ISubjectService _subjectService;
        private IMapper _mapper;

        public QuestionsController(IQuestionService questionService, ISubjectService subjectService)
        {
            _questionService = questionService;
            _subjectService = subjectService;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuestionViewModel, QuestionDto>();
                cfg.CreateMap<QuestionDto, QuestionViewModel>();

                cfg.CreateMap<SubjectViewModel, SubjectDto>();
                cfg.CreateMap<SubjectDto, SubjectViewModel>();
            });
            _mapper = config.CreateMapper();
        }

            

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionDto question = _questionService.GetQuestion(id.Value);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create(int testId)
        {
            var model = new QuestionViewModel();
            model.TestId = testId;
            return View(model);
        }

        // POST: Questions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionViewModel question, int? testId)  // [Bind(Include = "QuestionId,Name,Complexity,Rate,Duration,IsApproved")]
        {
            if (ModelState.IsValid)
            {
                QuestionDto questionDto = _mapper.Map<QuestionViewModel, QuestionDto>(question);
                _questionService.AddQuestion(questionDto);
                return RedirectToAction("Details", "Tests", new { id = question.TestId });
            }
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QuestionDto question = _questionService.GetQuestion(id.Value);
            QuestionViewModel questionVewModel = _mapper.Map<QuestionDto, QuestionViewModel>(question);

            if (question == null)
            {
                return HttpNotFound();
            }
            return View(questionVewModel);
        }

        // POST: Questions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionViewModel question, int? testId)
        {
            if (ModelState.IsValid)
            {
                QuestionDto questionDto = _mapper.Map<QuestionViewModel, QuestionDto>(question);
                _questionService.EditQuestion(questionDto);
                return RedirectToAction("Details", "Tests", new { id = question.TestId });
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id, int? testId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _questionService.DeleteQuestion(id.Value);
            return RedirectToAction("Details", "Tests", new { id = testId });
        }
    }
}
