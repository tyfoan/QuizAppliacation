using Enums;
using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class TestDto
    {
        public int TestId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        public int Duration { get; set; }
        public bool IsApproved { get; set; }

        public List<ThemeDto> Themes { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public List<TestPassDto> TestPasses { get; set; }
    }
}
