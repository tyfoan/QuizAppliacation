using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    class SubjectRepository: IRepository<Subject>
    {
        private readonly QuizContext _db;
        public SubjectRepository(QuizContext context)
        {
            _db = context;
        }

        public IEnumerable<Subject> GetAll()
        {
            return _db.Subjects;
        }

        
        public Subject Get(int id)
        {
            return _db.Subjects.Find(id);
        }

        public void Create(Subject item)
        {
            _db.Subjects.Add(item);
        }

        public void Update(Subject item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Subject subj = _db.Subjects.Find(id);
            if (subj != null)
            {
                _db.Subjects.Remove(subj);
            }
        }

        public IEnumerable<Subject> Find(Func<Subject, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
