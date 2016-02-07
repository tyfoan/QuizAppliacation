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
        public Enum Complexity { get; set; }
        public int Rate { get; set; }
        public int QuestionAmount { get; set; }
        public int Duration { get; set; }


        public ICollection<TestPass> TestPases { get; set; }
        public ICollection<Question> Questions { get; set; }
        public Subject Subject { get; set; }

    }
}
