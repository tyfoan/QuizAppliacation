using Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationMVC.Models.ViewModels
{
    public class Subject
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        public int TestAmount { get; set; }


        public ICollection<Test> Tests { get; set; }
        public User User { get; set; }
    }
}
