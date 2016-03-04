using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DTO;

namespace PresentationMVC.Models.ViewModels
{
    public class TestPass
    {
        public Guid TestPassId { get; set; }
        public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }


        public Test Test { get; set; }
        //public UserDto User { get; set; }
        public List<Question> Questions { get; set; } 
    }
}
