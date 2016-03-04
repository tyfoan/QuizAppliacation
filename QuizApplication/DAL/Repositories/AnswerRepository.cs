using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {
        private readonly QuizContext _db;
        public AnswerRepository(QuizContext context)
        {
            _db = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return _db.Answers;
        }

        public Answer Get(Guid id)
        {
            return _db.Answers.Find(id);
        }

        public void Create(Answer item)
        {
            _db.Answers.Add(item);
        }

        public void Update(Answer item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Answer answer = _db.Answers.Find(id);
            if (answer != null)
            {
                _db.Answers.Remove(answer);
            }
        }
    }
}
