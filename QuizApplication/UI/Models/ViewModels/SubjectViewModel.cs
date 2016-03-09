using Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models.ViewModels
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        public int TestAmount { get; set; }


        public List<TestViewModel> Tests { get; set; }
    }
}
