using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationMVC.Models.ViewModels
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public string QuestionContent { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
