using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TestDTO
    {
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        public int QuestionAmount { get; set; }
        public int Duration { get; set; }


        public List<TestPassDTO> TestPases { get; set; }
        public List<QuestionDTO> Questions { get; set; }

    }
}
