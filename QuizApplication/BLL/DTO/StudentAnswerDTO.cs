using System;
namespace BLL.DTO
{
    public class StudentAnswerDto
    {
        public Guid StudentAnswerGuid { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
    }
}