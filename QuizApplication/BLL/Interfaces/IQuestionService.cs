using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<QuestionDto> GetQuestions(int testId);
        QuestionDto GetQuestion(int id);
        void AddQuestion(QuestionDto question);
        void DeleteQuestion(int id);
        void EditQuestion(QuestionDto question);
    }
}
