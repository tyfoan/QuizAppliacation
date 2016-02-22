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
        private QuizContext db;
        private AnswerRepository answerRep;
        private QuestionRepository questionRep;
        private TestRepository testRep;
        private UserRepository userRep;
        private SubjectRepository subjectRep;
        private ThemeRepository themeRep;

        public EFUnitOfWork()
        {
            db = new QuizContext();
        }


        public IRepository<Theme> Themes
        {
            get
            {
                if (themeRep == null)
                    themeRep = new ThemeRepository(db);
                return themeRep;
            }
        }

        public IRepository<Answer> Answers
        {
            get 
            {
                if (answerRep == null)
                    answerRep = new AnswerRepository(db);
                return answerRep;
            }
        }

        public IRepository<Question> Questions
        {
            get 
            {
                if (questionRep == null)
                    questionRep = new QuestionRepository(db);
                return questionRep;

            }
        }

        public IRepository<Subject> Subjects
        {
            get
            {
                if (subjectRep == null)
                    subjectRep = new SubjectRepository(db);
                return subjectRep;
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                if (testRep == null)
                    testRep = new TestRepository(db);
                return testRep;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRep == null)
                    userRep = new UserRepository(db);
                return userRep;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
