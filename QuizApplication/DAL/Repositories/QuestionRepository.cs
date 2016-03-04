using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private readonly QuizContext _db;
        public QuestionRepository(QuizContext context)
        {
            this._db = context;
        }

        public IEnumerable<Question> GetAll()
        {
            return _db.Questions;
        }

        public Question Get(Guid id)
        {
            return _db.Questions.Find(id);
        }

        public void Create(Question item)
        {
            _db.Questions.Add(item);
        }

        public void Update(Question item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Question question = _db.Questions.Find(id);
            if (question != null)
            {
                _db.Questions.Remove(question);
            }
        }
    }
}
