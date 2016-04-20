using System;
using System.Collections.Generic;

namespace UI.Models.ViewModels
{
    public class StudentAnswerViewModel
    {
        public Guid StudentAnswersGuid { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
    }
}