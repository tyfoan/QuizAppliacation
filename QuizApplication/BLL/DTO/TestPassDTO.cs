using System;

namespace BLL.DTO
{
    public class TestPassDto
    {
        public int TestPassId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }
    }
}
