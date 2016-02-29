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
    class TestRepository : IRepository<Test>
    {
        private QuizContext db;
        public TestRepository(QuizContext context)
        {
            this.db = context;
        }


        public IEnumerable<Test> GetAll()
        {
            return db.Tests;
        }

        public Test Get(Guid id)
        {
            return db.Tests.Find(id);
        }

        public void Create(Test item)
        {
            db.Tests.Add(item);
        }

        public void Update(Test item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Test test = db.Tests.Find(id);
            if (test != null)
            {
                db.Tests.Remove(test);
            }
        }
    }
}
