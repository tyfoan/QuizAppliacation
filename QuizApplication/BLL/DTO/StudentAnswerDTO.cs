using System;
namespace BLL.DTO
{
    public class StudentAnswerDto
    {
        public Guid StudentAnswerId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid UserId { get; set; }
        public Guid AnswerId { get; set; }
    }
}