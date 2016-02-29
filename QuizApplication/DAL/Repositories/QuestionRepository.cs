using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private QuizContext db;
        public QuestionRepository(QuizContext context)
        {
            this.db = context;
        }

        public IEnumerable<Question> GetAll()
        {
            return db.Questions;
        }

        public Question Get(Guid id)
        {
            return db.Questions.Find(id);
        }

        public void Create(Question item)
        {
            db.Questions.Add(item);
        }

        public void Update(Question item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Question question = db.Questions.Find(id);
            if (question != null)
            {
                db.Questions.Remove(question);
            }
        }
    }
}
