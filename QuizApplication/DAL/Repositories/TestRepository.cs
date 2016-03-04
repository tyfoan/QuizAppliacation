using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

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

        public Test Get(Guid id)
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

        public void Delete(Guid id)
        {
            Test test = _db.Tests.Find(id);
            if (test != null)
            {
                _db.Tests.Remove(test);
            }
        }
    }
}
