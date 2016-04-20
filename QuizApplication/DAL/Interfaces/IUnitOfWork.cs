using DAL.Entities;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRepository<Role> Roles{ get; }
        IRepository<Answer> Answers { get; }
        IRepository<Question> Questions { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<Test> Tests { get; }
        IStudentAnswerRepository StudentAnswers { get; }
        void Save();
    }
}
