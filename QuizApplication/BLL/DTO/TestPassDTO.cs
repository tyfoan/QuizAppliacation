using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TestPassDTO
    {
        public Guid TestPassId { get; set; }
        public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }


    }
}
