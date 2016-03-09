using System.Collections.Generic;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<SubjectDto> GetSubjects();
        SubjectDto GetSubject(int id);
        void AddSubject(SubjectDto subject);
        void DeleteSubject(int id);
        void EditSubject(SubjectDto subject);

    }
}
