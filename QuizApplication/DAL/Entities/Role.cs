﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
