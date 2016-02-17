using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Test
    {
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        public int QuestionAmount { get; set; }
        public int Duration { get; set; }


        public virtual ICollection<Question> Questions { get; set; }

        //public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<TestPass> TestPasses { get; set; }

    }
}
