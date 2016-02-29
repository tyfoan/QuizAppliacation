using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public string QuestionContent { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
        public virtual Test Test { get; set; }
    }
}
