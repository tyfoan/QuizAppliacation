using System;
using System.Collections.Generic;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class StudentAnswerRepository : IRepository<StudentAnswer>
    {
        private readonly QuizContext _db;

        public StudentAnswerRepository(QuizContext db)
        {
            _db = db;
        }

        public IEnumerable<StudentAnswer> GetAll()
        {
            return _db.StudentAnswers;
        }

        public StudentAnswer Get(int id)
        {
            return _db.StudentAnswers.Find(id);
        }

        public void Create(StudentAnswer item)
        {
            _db.StudentAnswers.Add(item);
        }

        public void Update(StudentAnswer item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            StudentAnswer studentAnswer = _db.StudentAnswers.Find(id);
            if (studentAnswer != null)
            {
                _db.StudentAnswers.Remove(studentAnswer);
            }
        }

        public IEnumerable<StudentAnswer> Find(Func<StudentAnswer, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
