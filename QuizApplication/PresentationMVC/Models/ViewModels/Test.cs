using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace PresentationMVC.Models.ViewModels
{
    public class Test
    {
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        public int QuestionAmount { get; set; }
        public int Duration { get; set; }


        public List<Question> Questions { get; set; }
        public List<TestPass> TestPasses { get; set; }

    }
}
