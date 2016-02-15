using DAL.Entities;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SubjectDTO
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        public int TestAmount { get; set; }


        public List<TestDTO> Tests { get; set; }
    }
}
