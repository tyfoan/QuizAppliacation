using DAL.Entities;
using Enums;
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
        public int Duration { get; set; }
        public bool IsApproved { get; set; }


        public List<ThemeDTO> Themes { get; set; }
        public List<QuestionDTO> Questions { get; set; }
        public List<TestPassDTO> TestPasses { get; set; }
    }
}
