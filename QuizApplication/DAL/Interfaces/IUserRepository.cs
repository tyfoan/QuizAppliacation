using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        User Get(int id);
        void Delete(int id);
        IEnumerable<User> GetAll();
        void Create(User item);
        void Update(User item);
        User First(Func<User, Boolean> predicate);
    }
}
