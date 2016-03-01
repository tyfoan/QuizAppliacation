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
    class UserRepository: IRepository<ApplicationUser>
    {
        private QuizContext db;
        public UserRepository(QuizContext context)
        {
            this.db = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return db.Users;
        }

        public ApplicationUser Get(Guid id)
        {
            return db.Users.Find(id);
        }

        public void Create(ApplicationUser item)
        {
            db.Users.Add(item);
        }

        public void Update(ApplicationUser item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            ApplicationUser user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }
    }
}
