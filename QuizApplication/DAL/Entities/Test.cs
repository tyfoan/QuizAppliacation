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
        public int TestId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; } //сложность теста
        public Rate? Rate { get; set; } //рейт теста. 1-5 звездочек. Общее-кол-во звездочек / кол-во отзывов = Rate.
        public int Duration { get; set; }
        public bool IsApproved { get; set; }
        public int SubjectId { get; set; }



        public virtual ICollection<Question> Questions { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<TestPass> TestPasses { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
    }
}
