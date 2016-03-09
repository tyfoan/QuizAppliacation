using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAnswerService
    {
        IEnumerable<AnswerDto> GetAnswers(int testId);
        AnswerDto GetAnswer(int id);
        void AddAnswer(AnswerDto answer);
        void DeleteAnswer(int id);
        void EditAnswer(AnswerDto answer);
    }
}
