using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    public class TestPass
    {
        public int TestPassId { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }


        public virtual Test Test { get; set; }
        public virtual User User { get; set; }
    }
}
