using System;

namespace BLL.DTO
{
    public class TestPassDto
    {
        public Guid TestPassId { get; set; }
        public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }
    }
}
