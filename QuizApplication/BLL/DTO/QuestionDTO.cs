using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        public string QuestionContent { get; set; }

        public List<AnswerDto> Answers { get; set; }
        public List<StudentAnswerDto> StudentAnswers { get; set; }
    }
}
