using DAL.Interfaces;
using System;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.EF;
using DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Repositories.Auth;

namespace DAL.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly QuizContext _db;
        private AnswerRepository _answerRep;
        private QuestionRepository _questionRep;
        private TestRepository _testRep;
        private SubjectRepository _subjectRep;
        private ThemeRepository _themeRep;
        private StudentAnswerRepository _studentAnswerRep;

        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;
        private readonly IClientManager _clientManager;

        public EfUnitOfWork()
        {
            _db = new QuizContext();
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            _clientManager = new ClientManager(_db);
        }


        public IRepository<Theme> Themes
        {
            get
            {
                if (_themeRep == null)
                    _themeRep = new ThemeRepository(_db);
                return _themeRep;
            }
        }

        public IRepository<Answer> Answers
        {
            get 
            {
                if (_answerRep == null)
                    _answerRep = new AnswerRepository(_db);
                return _answerRep;
            }
        }

        public IRepository<Question> Questions
        {
            get 
            {
                if (_questionRep == null)
                    _questionRep = new QuestionRepository(_db);
                return _questionRep;

            }
        }

        public IRepository<Subject> Subjects
        {
            get
            {
                if (_subjectRep == null)
                    _subjectRep = new SubjectRepository(_db);
                return _subjectRep;
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                if (_testRep == null)
                    _testRep = new TestRepository(_db);
                return _testRep;
            }
        }
    

        public IRepository<StudentAnswer> StudentAnswers
        {
            get
            {
                if (_studentAnswerRep == null)
                    _studentAnswerRep = new StudentAnswerRepository(_db);
                return _studentAnswerRep;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
        private bool _disposed;
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                    _roleManager.Dispose();
                    _clientManager.Dispose();
                    _db.Dispose();
                }
                _disposed = true;
            }
        }


        public ApplicationUserManager UserManager
        {
            get { return _userManager; }
        }

        public IClientManager ClientManager
        {
            get { return _clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager; }
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
