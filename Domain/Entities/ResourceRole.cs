﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ResourceRole
    {
        public Guid Id { get; set; }
        public string ResourceId { get; set; }
        public string RoleId { get; set; }
    }
}
