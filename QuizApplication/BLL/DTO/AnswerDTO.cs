using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class AnswerDto
    {
        public int AnswerId { get; set; }
        public bool IsTrue { get; set; }
        public string ContentAnswer { get; set; }
        public string TrueAnswer { get; set; }
        public string StudentsAnswer { get; set; }
        public List<StudentAnswerDto> StudentAnswers { get; set; }
        public List<AnswerDto> AnswerDtos { get; set; }
    }
}
