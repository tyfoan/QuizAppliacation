using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;

using UI.Models.ViewModels;

namespace UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class SubjectsController : Controller
    {
        private ISubjectService _service;
        private IMapper _mapper;

        public SubjectsController(ISubjectService service)
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

        // GET: Questions
        public ActionResult Index()
        {
            List<SubjectViewModel> subjects = _mapper.Map<IEnumerable<SubjectDto>, List<SubjectViewModel>>(_service.GetSubjects());
            return View(subjects);
        }

        public ActionResult Details(int? subjectId)
        {
            ViewBag.SubjectId = subjectId;
            SubjectDto subject = _service.GetSubject(subjectId.Value);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }


        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectViewModel subject) //[Bind(Include = "SubjectId,Name,Complexity,Rate,TestAmount")]
        {
            if (ModelState.IsValid)
            {
                SubjectDto subjectDto = _mapper.Map<SubjectViewModel, SubjectDto>(subject);
                _service.AddSubject(subjectDto);
                return RedirectToAction("Index");
            }
            
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? SubjectId)
        {
            if (SubjectId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SubjectDto subjectDto = _service.GetSubject(SubjectId.Value);
            SubjectViewModel subjectViewModel = _mapper.Map<SubjectDto, SubjectViewModel>(subjectDto);
            if (subjectDto == null)
            {
                return HttpNotFound();
            }
            return View(subjectViewModel);
        }

        // POST: Subjects/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectViewModel subject) //[Bind(Include = "SubjectId,Name,Complexity,Rate,TestAmount")] 
        {
            if (ModelState.IsValid)
            {
                SubjectDto subjectDto = _mapper.Map<SubjectViewModel, SubjectDto>(subject);
                _service.EditSubject(subjectDto);
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? SubjectId)
        {
            _service.DeleteSubject(SubjectId.Value);
            return RedirectToAction("Index");
        }
    }
}
