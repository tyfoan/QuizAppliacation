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
    public class AnswerRepository : IRepository<Answer>
    {
        private QuizContext db;
        public AnswerRepository(QuizContext context)
        {
            this.db = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return db.Answers;
        }

        public Answer Get(Guid id)
        {
            return db.Answers.Find(id);
        }

        public void Create(Answer item)
        {
            db.Answers.Add(item);
        }

        public void Update(Answer item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Answer answer = db.Answers.Find(id);
            if (answer != null)
            {
                db.Answers.Remove(answer);
            }
        }
    }
}
