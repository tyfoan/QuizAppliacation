using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public  interface IStudentAnswerRepository
    {
        IEnumerable<StudentAnswer> GetAll();
        StudentAnswer Get(int id);
        void Create(StudentAnswer item);
        void Update(StudentAnswer item);
        void Delete(int id);
        StudentAnswer Find(Func<StudentAnswer, bool> predicate);
    }
}
