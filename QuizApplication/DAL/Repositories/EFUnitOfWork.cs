using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;
using DAL.EF;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private QuizContext _db;
        private AnswerRepository _answerRep;
        private QuestionRepository _questionRep;
        private TestRepository _testRep;
        private UserRepository _userRep;
        private SubjectRepository _subjectRep;
        private ThemeRepository _themeRep;
        private StudentAnswerRepository _studentAnswerRep;

        public EFUnitOfWork()
        {
            _db = new QuizContext();
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

        public IRepository<User> Users
        {
            get
            {
                if (_userRep == null)
                    _userRep = new UserRepository(_db);
                return _userRep;
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
        private bool _disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

    }
}
