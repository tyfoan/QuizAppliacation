using Enums;
using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class SubjectDto
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        public int TestAmount { get; set; }


        public List<TestDto> Tests { get; set; }
    }
}
