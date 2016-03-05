﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private QuizContext _db;

        public RoleRepository(QuizContext db)
        {
            _db = db;
        }

        public IEnumerable<Role> GetAll()
        {
            return _db.Roles;
        }

        public Role Get(Guid id)
        {
            return _db.Roles.Find(id);
        }

        public void Create(Role item)
        {
            _db.Roles.Add(item);
        }

        public void Update(Role item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Role role = _db.Roles.Find(id);
            if (role != null)
            {
                _db.Roles.Remove(role); 
            }
        }
    }
}