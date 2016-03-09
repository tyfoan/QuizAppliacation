using System.Collections.Generic;

namespace UI.Models.ViewModels
{
    public class AnswerViewModel
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public bool IsTrue { get; set; }
        public string ContentAnswer { get; set; }
        public bool IsAnswered { get; set; }
        public QuestionViewModel Tests { get; set; }
    }
}
