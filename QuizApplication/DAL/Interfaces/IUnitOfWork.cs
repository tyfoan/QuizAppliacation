using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Answer> Answers { get; }
        IRepository<Question> Questions { get; }
        IRepository<Subject> Subjects { get; }
        //IRepository<Role> Roles { get; }
        IRepository<Test> Tests { get; }
        IRepository<User> Users { get; }
        //IRepository<TestPass> TestPasses { get; }
        void Save();
    }
}
