using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class StudentAnswer
    {
        public int StudentAnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}
