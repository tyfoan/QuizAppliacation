using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    class UserRepository: IRepository<User>
    {
        private readonly QuizContext _db;
        public UserRepository(QuizContext context)
        {
            _db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public User Get(Guid id)
        {
            return _db.Users.Find(id);
        }

        public void Create(User item)
        {
            _db.Users.Add(item);
        }

        public void Update(User item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            User user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Users.Remove(user);
            }
        }
    }
}
