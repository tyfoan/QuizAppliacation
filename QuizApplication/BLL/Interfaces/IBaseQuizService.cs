using BLL.DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IBaseQuizService
    {
        TestDto Get(Guid id);
        IEnumerable<SubjectDto> GetAll();
        void Dispose();
        void AddStudentAnswer(StudentAnswerDto studentAnswer);
    }
}
