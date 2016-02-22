using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class QuestionDTO
    {
        public Guid QuestionId { get; set; }
        public string QuestionContent { get; set; }

        public List<AnswerDTO> Answers { get; set; }
    }
}
