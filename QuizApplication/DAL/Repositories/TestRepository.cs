using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    class TestRepository : IRepository<Test>
    {
        private readonly QuizContext _db;
        public TestRepository(QuizContext context)
        {
            _db = context;
        }


        public IEnumerable<Test> GetAll()
        {
            return _db.Tests;
        }

        public Test Get(int id)
        {
            return _db.Tests.Find(id);
        }

        public void Create(Test item)
        {
            _db.Tests.Add(item);
        }

        public void Update(Test item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Test test = _db.Tests.Find(id);
            if (test != null)
            {
                _db.Tests.Remove(test);
            }
        }

        public IEnumerable<Test> Find(Func<Test, bool> predicate)
        {
            return _db.Tests.Where(predicate);
        }
    }
}
