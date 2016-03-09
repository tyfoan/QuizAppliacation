﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Theme
    {
        public int ThemeId { get; set; }
        public string Name { get; set; }

        public virtual Test Test { get; set; }
    }
}
