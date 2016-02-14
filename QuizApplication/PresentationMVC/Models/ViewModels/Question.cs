using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationMVC.Models.ViewModels
{
    public class Question
    {
        public Guid GuestionId { get; set; }
        public string QuestionContent { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public Test Test { get; set; }
    }
}
