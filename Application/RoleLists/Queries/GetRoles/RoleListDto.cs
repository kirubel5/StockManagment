﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoleLists.Queries.GetRoles
{
    public class RoleListDto
    {
        public IList<string> Lists { get; set; } = new List<string>();
    }
}
