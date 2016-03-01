using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Subject
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        public int TestAmount { get; set; }


        public virtual ICollection<Test> Tests { get; set; }       
        public virtual ApplicationUser User { get; set; }
    }
}
