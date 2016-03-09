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
    public class TestsController : Controller
    {
        private ITestService _testService;
        private ISubjectService _subjectService;
        private IMapper _mapper;

        public TestsController(ITestService testService, ISubjectService subjectService)
        {
            _testService = testService;
            _subjectService = subjectService;

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

            
       
        public ActionResult Details(int? id)
        {
            ViewBag.TestId = id;
            TestDto test = _testService.GetTest(id.Value);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Tests/Create
        public ActionResult Create(int subjectId)
        {
            var model = new TestViewModel();
            model.SubjectId = subjectId;
            return View(model);
        }

        // POST: Tests/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestViewModel test, int? subjectRedirrect)  // [Bind(Include = "TestId,Name,Complexity,Rate,Duration,IsApproved")]
        {
            if (ModelState.IsValid)
            {
                TestDto testDto = _mapper.Map<TestViewModel, TestDto>(test);
                _testService.AddTest(testDto);
                return RedirectToAction("Details", "Subjects", new { subjectId = test.SubjectId });
            }
            return View(test);

        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TestDto test = _testService.GetTest(id.Value);
            TestViewModel testVewModel = _mapper.Map<TestDto, TestViewModel>(test);

            if (test == null)
            {
                return HttpNotFound();
            }
            return View(testVewModel);
        }

        // POST: Tests/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TestViewModel test, int? subjectId)
        {
            if (ModelState.IsValid)
            {
                TestDto testDto = _mapper.Map<TestViewModel, TestDto>(test);
                _testService.EditTest(testDto);
                return RedirectToAction("Details", "Subjects", new { subjectId });
            }
            return View(test);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int? id, int? subjectId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _testService.DeleteTest(id.Value);
            return RedirectToAction("Details", "Subjects", new { subjectId = subjectId });
        }
    }
}
