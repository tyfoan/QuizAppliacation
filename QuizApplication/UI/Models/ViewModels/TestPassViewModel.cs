using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DTO;

namespace UI.Models.ViewModels
{
    public class TestPassViewModel
    {
        public int TestPassId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }


        public TestViewModel Test { get; set; }
        //public UserDto User { get; set; }
        public List<QuestionViewModel> Questions { get; set; } 
    }
}
