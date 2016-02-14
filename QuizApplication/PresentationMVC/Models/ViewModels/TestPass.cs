using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public User User { get; set; }
    }
}
