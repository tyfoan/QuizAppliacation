using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models.ViewModels
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public List<UserViewModel> Users { get; set; }

    }
}
