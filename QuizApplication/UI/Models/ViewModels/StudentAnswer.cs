using System;
using System.Collections.Generic;

namespace UI.Models.ViewModels
{
    public class StudentAnswer
    {
        public Guid StudentAnswersId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid UserId { get; set; }
        public Guid AnswerId { get; set; }
    }
}