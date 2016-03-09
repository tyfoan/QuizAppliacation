using System.Collections.Generic;
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
        private IAnswerService _questionService;
        private ISubjectService _subjectService;
        private IMapper _mapper;

        public AnswersController(IAnswerService questionService, ISubjectService subjectService)
        {
            _questionService = questionService;
            _subjectService = subjectService;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnswerViewModel, AnswerDto>();
                cfg.CreateMap<AnswerDto, AnswerViewModel>();

                cfg.CreateMap<SubjectViewModel, SubjectDto>();
                cfg.CreateMap<SubjectDto, SubjectViewModel>();
            });
            _mapper = config.CreateMapper();
        }



        // GET: Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerDto question = _questionService.GetAnswer(id.Value);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Answers/Create
        public ActionResult Create()
        {
            var subjects = _mapper.Map<IEnumerable<SubjectDto>, List<SubjectViewModel>>(_subjectService.GetSubjects());
            var model = new AnswerViewModel();
            return View(model);
        }

        // POST: Answers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnswerViewModel question)  // [Bind(Include = "AnswerId,Name,Complexity,Rate,Duration,IsApproved")]
        {
            if (ModelState.IsValid)
            {
                AnswerDto questionDto = _mapper.Map<AnswerViewModel, AnswerDto>(question);
                _questionService.AddAnswer(questionDto);
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AnswerDto question = _questionService.GetAnswer(id.Value);
            AnswerViewModel questionVewModel = _mapper.Map<AnswerDto, AnswerViewModel>(question);

            if (question == null)
            {
                return HttpNotFound();
            }
            return View(questionVewModel);
        }

        // POST: Answers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnswerViewModel question)
        {
            if (ModelState.IsValid)
            {
                AnswerDto questionDto = _mapper.Map<AnswerViewModel, AnswerDto>(question);
                _questionService.EditAnswer(questionDto);
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _questionService.DeleteAnswer(id.Value);
            return RedirectToAction("Index");
        }
    }
}
