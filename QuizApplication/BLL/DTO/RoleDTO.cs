using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RoleDTO
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public IList<UserDTO> Users { get; set; }
    }
}
