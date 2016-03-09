using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public List<UserDto> Users { get; set; }
    }
}
