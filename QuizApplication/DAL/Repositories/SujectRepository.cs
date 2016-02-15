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
    class SubjectRepository: IRepository<Subject>
    {
        private QuizContext db;
        public SubjectRepository(QuizContext context)
        {
            this.db = context;
        }

        public IEnumerable<Subject> GetAll()
        {
            return db.Subjects;
        }
        
        public Subject Get(Guid id)
        {
            return db.Subjects.Find(id);
        }

        public void Create(Subject item)
        {
            db.Subjects.Add(item);
        }

        public void Update(Subject item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Subject subj = db.Subjects.Find(id);
            if (subj == null)
            {
                db.Subjects.Remove(subj);
            }
        }
    }
}
