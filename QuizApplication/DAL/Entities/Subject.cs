using Enums;
using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        public int TestAmount { get; set; }


        public virtual ICollection<Test> Tests { get; set; }       
        public virtual User User { get; set; }
    }
}
