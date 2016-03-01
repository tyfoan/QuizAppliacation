using DAL.Entities;
using System;
using System.Threading.Tasks;
using DAL.Identity;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Answer> Answers { get; }
        IRepository<Question> Questions { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<Test> Tests { get; }
        IRepository<StudentAnswer> StudentAnswers { get; }
        void Save();


        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
